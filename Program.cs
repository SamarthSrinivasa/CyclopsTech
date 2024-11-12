using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Open the cameras
        VideoCapture camera1 = new VideoCapture(1);
        VideoCapture camera2 = new VideoCapture(2);

        // Check if cameras are opened
        if (!camera1.IsOpened || !camera2.IsOpened)
        {
            Console.WriteLine("Cannot open camera");
            return;
        }

        // Define the codec and create VideoWriter objects
        VideoWriter out1 = new VideoWriter("output1.avi", VideoWriter.Fourcc('X', 'V', 'I', 'D'), 20.0, new Size(640, 480), true);
        VideoWriter out2 = new VideoWriter("output2.avi", VideoWriter.Fourcc('X', 'V', 'I', 'D'), 20.0, new Size(640, 480), true);

        Mat frame1 = new Mat();
        Mat frame2 = new Mat();

        // Main loop
        while (true)
        {
            // Read frames from both cameras
            camera1.Read(frame1);
            camera2.Read(frame2);

            if (!frame1.IsEmpty)
            {
                out1.Write(frame1);
                CvInvoke.Imshow("Camera 1", frame1);
            }

            if (!frame2.IsEmpty)
            {
                out2.Write(frame2);
                CvInvoke.Imshow("Camera 2", frame2);
            }

            // Break the loop on 'q' key press
            if (CvInvoke.WaitKey(1) == 'q')
            {
                break;
            }
        }

        // Release the camera and output objects
        camera1.Dispose();
        camera2.Dispose();
        out1.Dispose();
        out2.Dispose();
        CvInvoke.DestroyAllWindows();
    }
}
