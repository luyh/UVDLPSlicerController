using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Device_Interface.DeepImager
{
    /// <summary>
    /// this class is used to decode the various messages sent from the printer to the host controller
    /// </summary>
    public class DIDriverStatus
    {
        // parse the 13 byte respone
        public static byte MODE_PRINT = (byte)'P';
        public static byte MODE_CALIBRATE = (byte)'C';
        public static byte MODE_STANDBY = (byte)'S';
        public byte Mode;

        public static byte RESOLUTION_25 = 1;
        public static byte RESOLUTION_50 = 2;
        public static byte RESOLUTION_75 = 3;
        public static byte RESOLUTION_100 = 4;
        public static byte RESOLUTION_150 = 5;
        public static byte RESOLUTION_200 = 6;

        public byte Resolution; // x/y resolution

        public int ZPosSteps;  // 24 bytes
        public DIDriverStatus(byte[] data) 
        {
            // parse the response
            //checksum the message
            Mode = data[1];
            int tmp;
            ZPosSteps = data[2];
            tmp = data[3];
            tmp = tmp << 8;
            ZPosSteps |= tmp;

            tmp = data[4];
            tmp = tmp << 16;
            ZPosSteps |= tmp;

            Resolution = data[5];
        }
    }

    /*
Messages to PC 		-	Issued at System Status Change

	Byte 0		'#'	to PC

	Byte 1		Current Mode
			'P'	Print	  -	Print mode,
			'C'	Cal	  -	Calibrate Mode (Activated when Cal box attached)
			'S'	Standby  -	Standby
	

	Byte 2		Build Z Position (LSB)	Steps from park (0) (@ .0005 / step, max range is 600+ feet)
	Byte 3		Build Z Position 
	Byte 4		Build Z Position (MSB)

	Byte 5		Current Resolution Code 
			‘1’    =   25 um
			‘2’    =   50 um
			‘3’    =   75 um
			‘4’    = 100 um
			‘5’    = 150 um
			‘6’    = 200 um

		
	Byte 6		Printer Status
			Bit 0 -	Door Open
			Bit 1 -	Proj On
			Bit 2 -	Pump On - Fill
			Bit 3 -	Pump On - Drain
			Bit 4 -	Build Ready 			(New slice may be projected)
			Bit 5 -	
			Bit 6 -	Cal Done for Current Resolution Code – Go to Next Code
			Bit 7 -	Cal Active			(Service Box Connected)
		
	Byte 7		Home Status
			Bit 0 -	Proj Throw Home   
			Bit 1 -	Proj X Home	 	   
			Bit 2 -	Proj Y Home	 
			Bit 3 -	Proj Z Home	 
			Bit 4 -	Proj Focus Home	 
			Bit 5 -	Spare Home
			Bit 6 -	Build Home
			Bit 7 -	Build Home Limit
		
	Byte 8		Limit Status
			Bit 0 -	Proj Throw Limit 
			Bit 1 -	Proj X Limit
			Bit 2 -	Proj Y Limit
			Bit 3 -	Proj Z Limit
			Bit 4 -	Proj Focus Limit
			Bit 5 -	Spare Limit
			Bit 6 -	Build Park
			Bit 7 -	Door Lock			
	
	Byte 9		Scan Status 
			Bit 0 -	 Power On
			Bit 1 -	Table Active
			Bit 2 -	Table Home
			Bit 3 -	
			Bit 4 -	
			Bit 5 -	
			Bit 6 -
			Bit 7 -	Scan Complete			(Read Data from Camera A & B via USB Port)
		
	Byte 10		Error code 
			Bits 0 -> 6, error code = 0 -> 128
			Bit  7 -	Halt Flag

			0   = OK
			1   = Framing Error
			2   = Buff Ovfl
			3   = Type
			4   = Function Code
			5   = Command Code
			6   = Xsum
			7   = Message not permitted in Current Mode
			8   = Comm Error
			9   = +12v Fault
			10 = Build Stepper Fault
			11 = Proj Throw Stepper Fault 
			12 = Proj X Stepper Fault
			13 = Proj Y Stepper Fault
			14 = Proj Z Stepper Fault
			15 = Proj Focus Stepper Fault
			16 = Spare Stepper Fault
			17 = Build Stepper at limit (unexpected)
			18 = Proj Throw Stepper at limit (unexpected)
			19 = Proj X Stepper at limit (unexpected)
			20 = Proj Y Stepper at limit (unexpected)
			21 = Proj Z Stepper at limit (unexpected)
			22 = Proj Focus Stepper at limit (unexpected)
			23 = Spare Stepper at limit (unexpected)
			24 = Fill Pump motor over-current
			25 = Drain Pump motor over-current
			26 = Tilt motor over-current
			27 = Scan motor over-current
			28 = Build Home Not Valid
			29 = Build Home cannot be 0		  		  
		
	Byte 11		Firmware Version

	Byte 12		XSUM
 
     
     */
}
