using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Room 
    {
        double length;
        double width;
        double ceilingheight;
        int windows;
 
        ////////Properties
        public double Length
        { 
            get { return length; } 
            set 
            {
                if (value <= 0)
                    throw new ApplicationException("Room length cannot be less than or equal to zero!");
                else
                    length = value;
            } 
        }
        public double Width 
        { 
            get { return width; } 
            set 
            { 
                if (value <= 0)
                    throw new ApplicationException("Room width cannot be less than or equal to zero!");
                else
                    width = value; 
            } 
        }

        public double Ceilingheight
        { 
            get { return ceilingheight; } 
            set 
            {
                if (value <= 0 || value >3)
                    throw new ApplicationException("The ceiling height cannot be more than 3 meters and less than or equal to zero!");
                else
                    ceilingheight = value; 
            } 
        }

        public int Windows 
        { 
            get { return windows; } 
            set 
            { 
                if (value < 0)
                    throw new ApplicationException("The number of windows cannot be less than zero!");
                else
                    windows = value; 
            } 
        }

        public string State 
        { 
            get { return $"Area: {Area(length,width)} m2 \nVolume: {Volume(length,width,ceilingheight)} m3"; } 
        }


        //////Constructors
        public Room() : this(1,1,2,0) { }
        public Room(double length) : this(length,1,2,0) { }
        public Room(double length, double width) : this(length, width, 2, 0) { }
        public Room(double length, double width, double ceilingheight ) : this(length, width, ceilingheight, 0) { }
        public Room(double length, double width, double ceilingheight, int windows) 
        {
            Length = length;
            Width = width;
            Ceilingheight = ceilingheight;
            Windows = windows;
        }

        /////Methods
        public double Area(double wall1, double wall2) 
        {
            return wall1 * wall2;
        }

        public double Volume(double length, double width, double heigth) 
        {
            return length * width * heigth;
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double roomlength;
            double roomwidth;
            double roomheight;
            int roomwindows;

            Console.WriteLine("\tEnter room details ");
            Console.Write("Room length: ");
            roomlength = Convert.ToDouble(Console.ReadLine());

            Console.Write("Room width: ");
            roomwidth = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ceiling height: ");
            roomheight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Amount of windows: ");
            roomwindows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\tInfo");

            try
               {  
                if (roomlength == 0 && roomwidth == 0 && roomheight == 0 && roomwindows == 0)
                {
                    Room firstroom = new Room();
                    Console.WriteLine(firstroom.State);
                }
                else if (roomwidth == 0 && roomheight == 0 && roomwindows == 0)
                {
                    Room firstroom = new Room(roomlength);
                    Console.WriteLine(firstroom.State);
                }
                else if (roomheight == 0 && roomwindows == 0)
                {
                    Room firstroom = new Room(roomlength,roomwidth);
                    Console.WriteLine(firstroom.State);
                }
                else if (roomwindows == 0)
                {
                    Room firstroom = new Room(roomlength, roomwidth, roomheight);
                    Console.WriteLine(firstroom.State);
                }
                else 
                {   Room firstroom = new Room(roomlength, roomwidth, roomheight, roomwindows);
                    Console.WriteLine(firstroom.State);
                }
                    
               }
            catch (ApplicationException ex)
               {
                Console.WriteLine(ex.Message);
               }


        }
    }
}
