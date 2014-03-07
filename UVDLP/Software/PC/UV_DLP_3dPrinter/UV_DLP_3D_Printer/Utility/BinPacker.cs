using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UV_DLP_3D_Printer
{

    /// <summary>
    /// This class s used for packing models onto the given area of the build platform
    /// </summary>
    public class BinPacker
    {

        int m_packSize;
        int m_numPacked;
        List<Rect> m_rects;
        List<Rect> m_packs;
        List<int> m_roots;

           public class Rect
           {
                public int  x;
                public int y;
                public int w;
                public int h;
                public int ID;
                public int[] children;
                public bool rotated;
                public bool packed;

                public Rect(int size)
                {
                    x=0;
                    y=0;
                    w = size;
                    h = size;
                    rotated = false;
                    packed = false;
                    children = new int[2];
                    children[0] = -1;
                    children[1] = -1;

                }

                public Rect(int px, int py, int pw, int ph, int ID = 1)
                {
                    x = px; 
                    y = py;
                    w = pw;
                    h = ph;
                    rotated = false;
                    packed = false;
                    children = new int[2];
                    children[0] = -1;
                    children[1] = -1;

                }

                public int GetArea()
                {
                    return w * h;
                }

                public void Rotate() 
                {
                    int tmp = w;
                    w = h;
                    h = tmp;
                    rotated = !rotated;

                }
                public static bool operator >(Rect r1, Rect r2)
                {
                    return r1.GetArea() > r2.GetArea();
                }
                public static bool operator < (Rect r1, Rect r2)  
                {
                    return r1.GetArea() < r2.GetArea();
                }
        };

        void Clear()
        {
            m_packSize = 0;
            m_numPacked = 0;
            m_rects.Clear();
            m_packs.Clear();
            m_roots.Clear();
        }
    // ---------------------------------------------------------------------------

        bool Fits(Rect rect1,  Rect rect2, bool allowRotation)
        {

            // Check to see if rect1 fits in rect2, and rotate rect1 if that will
            // enable it to fit.

            if (rect1.w <= rect2.w && rect1.h <= rect2.h) 
            {
                return true;
            } else if (allowRotation && rect1.h <= rect2.w && rect1.w <= rect2.h) 
            {
                rect1.Rotate();
                return true;
            } 
            else 
            {
                return false;
            }
        }

        public bool RectIsValid(int i) 
        {
            return i >= 0 && i < (int)m_rects.Count;
        }

        // ---------------------------------------------------------------------------

        bool PackIsValid(int i) 
        {
            return i >= 0 && i < (int)m_packs.Count;
        }

    void AddPackToArray(int pack, List<int> array) 

    {
        int i = pack;
        if (m_packs[i].ID != -1) 
        {
            array.Add(m_packs[i].ID);
            array.Add(m_packs[i].x);
            array.Add(m_packs[i].y);
            //array.Add(m_packs[i].rotated);        
            array.Add(m_packs[i].rotated ? 1 : 0);

            if (m_packs[i].children[0] != -1) 
            {
                AddPackToArray(m_packs[i].children[0], array);
            }

            if (m_packs[i].children[1] != -1) 
            {
                AddPackToArray(m_packs[i].children[1], array);
            }
        }
    }
        /*
#ifndef BINPACKER_H

#define BINPACKER_H



#include <vector>



class BinPacker

{

public:



    // The input and output are in terms of vectors of ints to avoid

    // dependencies (although I suppose a public member struct could have been

    // used). The parameters are:

    

    // rects : An array containing the width and height of each input rect in

    // sequence, i.e. [w0][h0][w1][h1][w2][h2]... The IDs for the rects are

    // derived from the order in which they appear in the array.

    

    // packs : After packing, the outer array contains the packs (therefore

    // the number of packs is packs.size()). Each inner array contains a

    // sequence of sets of 4 ints. Each set represents a rectangle in the

    // pack. The elements in the set are 1) the rect ID, 2) the x position

    // of the rect with respect to the pack, 3) the y position of the rect

    // with respect to the pack, and 4) whether the rect was rotated (1) or

    // not (0). The widths and heights of the rects are not included, as it's

    // assumed they are stored on the caller's side (they were after all the

    // input to the function).

    

    // allowRotation : when true (the default value), the packer is allowed

    // the option of rotating the rects in the process of trying to fit them

    // into the current working area.



    void Pack(

        const std::vector<int>&          rects,

        std::vector< std::vector<int> >& packs,

        int                              packSize,

        bool                             allowRotation = true

    );



private:



 



    void Clear();

    void Fill(int pack, bool allowRotation);

    void Split(int pack, int rect);

    bool Fits(Rect& rect1, const Rect& rect2, bool allowRotation);

    void AddPackToArray(int pack, std::vector<int>& array) const;

    

    bool RectIsValid(int i) const;

    bool PackIsValid(int i) const;

    


};



#endif // #ifndef BINPACKER_H






#include "BinPacker.hpp"

#include <algorithm>



// ---------------------------------------------------------------------------

void BinPacker::Pack(

    const std::vector<int>&          rects,

    std::vector< std::vector<int> >& packs,

    int                              packSize,

    bool                             allowRotation)

{

    assert(!(rects.size() % 2));

    

    Clear();

    

    m_packSize = packSize;



    // Add rects to member array, and check to make sure none is too big

    for (size_t i = 0; i < rects.size(); i += 2) {

        if (rects[i] > m_packSize || rects[i + 1] > m_packSize) {

            assert(!"All rect dimensions must be <= the pack size");

        }

        m_rects.push_back(Rect(0, 0, rects[i], rects[i + 1], i >> 1));

    }

    

    // Sort from greatest to least area

    std::sort(m_rects.rbegin(), m_rects.rend());



    // Pack

    while (m_numPacked < (int)m_rects.size()) {

        int i = m_packs.size();

        m_packs.push_back(Rect(m_packSize));

        m_roots.push_back(i);

        Fill(i, allowRotation);

    }

    

    // Write out

    packs.resize(m_roots.size());

    for (size_t i = 0; i < m_roots.size(); ++i) {

        packs[i].clear();

        AddPackToArray(m_roots[i], packs[i]);

    }



    // Check and make sure all rects were packed

    for (size_t i = 0; i < m_rects.size(); ++i) {

        if (!m_rects[i].packed) {

            assert(!"Not all rects were packed");

        }

    }

}

// ---------------------------------------------------------------------------



// ---------------------------------------------------------------------------

void BinPacker::Fill(int pack, bool allowRotation)

{

    assert(PackIsValid(pack));



    int i = pack;

    

    // For each rect

    for (size_t j = 0; j < m_rects.size(); ++j) {

        // If it's not already packed

        if (!m_rects[j].packed) {

            // If it fits in the current working area

            if (Fits(m_rects[j], m_packs[i], allowRotation)) {

                // Store in lower-left of working area, split, and recurse

                ++m_numPacked;

                Split(i, j);

                Fill(m_packs[i].children[0], allowRotation);

                Fill(m_packs[i].children[1], allowRotation);

                return;

            }

        }

    }

}

// ---------------------------------------------------------------------------

void BinPacker::Split(int pack, int rect)

{

    assert(PackIsValid(pack));

    assert(RectIsValid(rect));

    

    int i = pack;

    int j = rect;



    // Split the working area either horizontally or vertically with respect

    // to the rect we're storing, such that we get the largest possible child

    // area.



    Rect left = m_packs[i];

    Rect right = m_packs[i];

    Rect bottom = m_packs[i];

    Rect top = m_packs[i];



    left.y += m_rects[j].h;

    left.w = m_rects[j].w;

    left.h -= m_rects[j].h;

    right.x += m_rects[j].w;

    right.w -= m_rects[j].w;

    

    bottom.x += m_rects[j].w;

    bottom.h = m_rects[j].h;

    bottom.w -= m_rects[j].w;

    top.y += m_rects[j].h;

    top.h -= m_rects[j].h;

    

    int maxLeftRightArea = left.GetArea();

    if (right.GetArea() > maxLeftRightArea) {

        maxLeftRightArea = right.GetArea();

    }

    

    int maxBottomTopArea = bottom.GetArea();

    if (top.GetArea() > maxBottomTopArea) {

        maxBottomTopArea = top.GetArea();

    }



    if (maxLeftRightArea > maxBottomTopArea) {

        if (left.GetArea() > right.GetArea()) {

            m_packs.push_back(left);

            m_packs.push_back(right);

        } else {

            m_packs.push_back(right);

            m_packs.push_back(left);

        }

    } else {

        if (bottom.GetArea() > top.GetArea()) {

            m_packs.push_back(bottom);

            m_packs.push_back(top);

        } else {

            m_packs.push_back(top);

            m_packs.push_back(bottom);

        }

    }

    

    // This pack area now represents the rect we've just stored, so save the

    // relevant info to it, and assign children.

    m_packs[i].w = m_rects[j].w;

    m_packs[i].h = m_rects[j].h;

    m_packs[i].ID = m_rects[j].ID;

    m_packs[i].rotated = m_rects[j].rotated;

    m_packs[i].children[0] = m_packs.size() - 2;

    m_packs[i].children[1] = m_packs.size() - 1;

    

    // Done with the rect

    m_rects[j].packed = true;

}



// ---------------------------------------------------------------------------


// ---------------------------------------------------------------------------


         
         */
    }
}
