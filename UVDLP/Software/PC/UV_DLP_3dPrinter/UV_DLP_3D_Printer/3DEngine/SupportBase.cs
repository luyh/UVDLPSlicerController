﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.Drawing;

namespace Engine3D
{
    public class SupportBase : Object3d
    {
        float[] FlatPoints = new float[] { 0, 2, 1, 2, 1, -2, 0, -2 };
        float[] InCornerPoints = new float[] { 0, 2, 1f, 2, 1.094f, 1.577f, 1.293f, 1.293f, 1.577f, 1.094f, 2, 1f, 2, 0 };
        float[] OutCornerPoints = new float[] { -2, 0, -2, 1, 0, 1, 0.423f, 0.906f, 0.707f, 0.707f, 0.906f, 0.423f, 1, 0, 1, -2, 0, -2 };
        const int FlatPat = 0x9;
        const int InCornetPat = 0xB;
        const int OutCornerPat = 0x1;
        const int DoubleInCornerPat = 0xA;
        int m_ntilesx, m_ntilesy;
        bool[,] m_tileMap;
        Point3d[,] m_tilePointsTop;
        Point3d[,] m_tilePointsBot;
        float m_spacing;
        float m_platex, m_platey; // bottom left corner of the plate
        Object3d m_refObj;
        float m_zbot = 0, m_ztop = 1;


        Point3d CreatePoint(float x, float y, float z, float scale, int rotate90, float offsx, float offsy)
        {
            Point3d pt = new Point3d(x * scale, y * scale, z);
            float t;
            switch (rotate90)
            {
                case 1:
                    t = pt.x;
                    pt.x = -pt.y;
                    pt.y = t;
                    break;

                case 2:
                    pt.x = -pt.x;
                    pt.y = -pt.y;
                    break;

                case 3:
                    t = pt.x;
                    pt.x = pt.y;
                    pt.y = -t;
                    break;
            }
            pt.x += offsx;
            pt.y += offsy;
            return pt;
        }

        Point3d GetTilePointTop(int ix, int iy)
        {
            if (m_tilePointsTop[ix, iy] == null)
                m_tilePointsTop[ix, iy] = new Point3d(m_platex + ix * m_spacing, m_platey + iy * m_spacing, m_ztop);
            return m_tilePointsTop[ix, iy];
        }

        Point3d GetTilePointBot(int ix, int iy)
        {
            if (m_tilePointsBot[ix, iy] == null)
                m_tilePointsBot[ix, iy] = new Point3d(m_platex + ix * m_spacing, m_platey + iy * m_spacing, m_zbot);
            return m_tilePointsBot[ix, iy];
        }

        void AddShape(float[] shape, Point3d ptTop, Point3d ptBot, float scale, int rotate90)
        {
            int i;
            int npoints = shape.Length / 2;
            // create 3d points from shape
            Point3d[] ptops = new Point3d[npoints];
            Point3d[] pbots = new Point3d[npoints];
            for (i = 0; i < npoints; i++)
            {
                ptops[i] = CreatePoint(shape[i*2], shape[i*2 + 1], ptTop.z, scale, rotate90, ptTop.x, ptTop.y);
                pbots[i] = CreatePoint(shape[i*2], shape[i*2 + 1], ptBot.z, scale, rotate90, ptBot.x, ptBot.y);
            }

            // top + bottom
            for (i = 0; i < npoints-1; i++)
            {
                Polygon plt = new Polygon();
                m_lstpolys.Add(plt);
                plt.m_points = new Point3d[3]; 
                plt.m_points[0] = ptTop;
                plt.m_points[1] = ptops[i + 1];
                plt.m_points[2] = ptops[i]; 
                Polygon plb = new Polygon();
                m_lstpolys.Add(plb);
                plb.m_points = new Point3d[3]; 
                plb.m_points[0] = ptBot;
                plb.m_points[1] = pbots[i];
                plb.m_points[2] = pbots[i + 1];  
            }
            // side
            for (i = 1; i < npoints-2; i ++)
            {
                Polygon plt = new Polygon();
                m_lstpolys.Add(plt);
                plt.m_points = new Point3d[3]; 
                plt.m_points[0] = ptops[i];
                plt.m_points[1] = ptops[i + 1];
                plt.m_points[2] = pbots[i];
                Polygon plb = new Polygon();
                m_lstpolys.Add(plb);
                plb.m_points = new Point3d[3]; 
                plb.m_points[0] = ptops[i+1];
                plb.m_points[1] = pbots[i + 1];
                plb.m_points[2] = pbots[i];
            }
        }

        void GenerateTileMap()
        {
            float objl = m_refObj.m_max.x - m_refObj.m_min.x;
            float objw = m_refObj.m_max.y - m_refObj.m_min.y;
            m_ntilesx = (int)(objl / m_spacing) + 3;
            m_ntilesy = (int)(objw / m_spacing) + 3;
            float platel = m_spacing * m_ntilesx;
            float platew = m_spacing * m_ntilesy;
            m_platex = m_refObj.m_min.x - (platel - objl) / 2;
            m_platey = m_refObj.m_min.y - (platew - objw) / 2;
            int x, y;
            m_tileMap = new bool[m_ntilesx, m_ntilesy];
            for (x = 0; x < m_ntilesx; x++)
                for (y = 0; y < m_ntilesy; y++)
                    m_tileMap[x, y] = false;
            foreach (Polygon ply in m_refObj.m_lstpolys)
                foreach (Point3d pt in ply.m_points)
                    m_tileMap[(int)((pt.x - m_platex) / m_spacing), (int)((pt.y - m_platey) / m_spacing)] = true;
        }

        void FillTiles()
        {
            m_tilePointsTop = new Point3d[m_ntilesx + 1, m_ntilesy + 1];
            m_tilePointsBot = new Point3d[m_ntilesx + 1, m_ntilesy + 1];
            int x, y;
            for (x = 0; x < m_ntilesx; x++)
            {
                for (y = 0; y < m_ntilesy; y++)
                {
                    if (m_tileMap[x, y])
                    {
                        Polygon plt = new Polygon();
                        m_lstpolys.Add(plt);
                        plt.m_points = new Point3d[3];
                        plt.m_points[0] = GetTilePointTop(x, y);
                        plt.m_points[1] = GetTilePointTop(x + 1, y);
                        plt.m_points[2] = GetTilePointTop(x + 1, y + 1);
                        plt = new Polygon();
                        m_lstpolys.Add(plt);
                        plt.m_points = new Point3d[3];
                        plt.m_points[0] = GetTilePointTop(x, y);
                        plt.m_points[1] = GetTilePointTop(x + 1, y + 1);
                        plt.m_points[2] = GetTilePointTop(x, y + 1);

                        Polygon plb = new Polygon();
                        m_lstpolys.Add(plb);
                        plb.m_points = new Point3d[3];
                        plb.m_points[0] = GetTilePointBot(x, y);
                        plb.m_points[1] = GetTilePointBot(x + 1, y + 1);
                        plb.m_points[2] = GetTilePointBot(x + 1, y);
                        plb = new Polygon();
                        m_lstpolys.Add(plb);
                        plb.m_points = new Point3d[3];
                        plb.m_points[0] = GetTilePointBot(x, y);
                        plb.m_points[1] = GetTilePointBot(x, y + 1);
                        plb.m_points[2] = GetTilePointBot(x + 1, y + 1);
                    }
                }
            }
        }

        void FillOutline()
        {
            int x, y;
            float scale = m_spacing / 4;

            for (x = 0; x < m_ntilesx - 1; x++)
            {
                for (y = 0; y < m_ntilesy - 1; y++)
                {
                    int pattern = 0;
                    if (m_tileMap[x, y + 1]) pattern |= 8;
                    if (m_tileMap[x + 1, y + 1]) pattern |= 4;
                    if (m_tileMap[x + 1, y]) pattern |= 2;
                    if (m_tileMap[x, y]) pattern |= 1;
                    if ((pattern == 0) || (pattern == 0xF))
                        continue; // for 0 and 15 no outline needed
                    bool patFound = false;
                    Point3d ptop = GetTilePointTop(x + 1, y + 1);
                    Point3d pbot = GetTilePointBot(x + 1, y + 1);
                    for (int i = 0; (i < 4) && !patFound; i++)
                    {
                        switch (pattern)
                        {
                            case OutCornerPat:
                                AddShape(OutCornerPoints, ptop, pbot, scale, i);
                                patFound = true;
                                break;
                            case InCornetPat:
                                AddShape(InCornerPoints, ptop, pbot, scale, i);
                                patFound = true;
                                break;
                            case FlatPat:
                                AddShape(FlatPoints, ptop, pbot, scale, i);
                                patFound = true;
                                break;
                            case DoubleInCornerPat:
                                AddShape(InCornerPoints, ptop, pbot, scale, i);
                                AddShape(InCornerPoints, ptop, pbot, scale, i+2);
                                patFound = true;
                                break;
                        }
                        if ((pattern & 1) != 0)
                            pattern |= 0x10;
                        pattern >>= 1;
                    }
                }
            }
        }

        // generate a support base plate under a reference object
        public void Generate(Object3d refObj, float spacing)
        {
            if ((refObj == null) || (spacing < 1))
                return;

            m_spacing = spacing;
            m_refObj = refObj;
            GenerateTileMap();
            FillTiles();
            FillOutline();
            foreach (Polygon ply in m_lstpolys)
            {
                ply.CalcCenter();
                ply.CalcNormal();
            }
            Update();
            SetColor(Color.Yellow);
        }
    }
}
