
/*
@author Filippo Di Paola
@date 07/08/2018
*/

/**
  * Add these 3 lines to at the start of your "PointCloudReciever.cs" files at the
  * top where all the other variables are declared.
  **/
public string uint8_topic = "/compressed/uint8points"; // The default subscriber.
private StandardByteArray uintmessage; // Custom message
private Point[] Points;  // This is the same "Points" in the sense of line 34 in PointCloud.cs
private DateTime start_time = DateTime.Now; // Only used if you want to time the script.

public void Start()
    {
	/// .... All the other instantiations happen here.... ///
	
	// Add this line to the Start() method of your code. You can appended it to the bottom of the function
	rosSocket.Subscribe(uint8_topic, "ros_bag_simulation/UInt8Array", CompressedPointSubscriber, UpdateTime);
		
	}
/**
  * Add this in-line with your other subscriber functions. This function creates a Points object
  * which can be processed in the same way as your ""pointCloud.Points" object attribute.
  * You will need to set up your "isMessageReceived" part in here as well. The points of the 
  * pointcloud2 data are stored in the ""Points" object created in this function. I have to state
  * that this code is slightly experimental (not tested), but I'm confident it works correctly.
  **/
private void CompressedPointSubscriber(Message message)
    {
            
            uintmessage = (StandardByteArray)message;
            int point_step = 32; // THIS IS THE POINT STEP FROM THE /camera/depth_registered/points TOPIC
			
			/// This section is taken directly from PointCloud.cs in the ROSBridge folder of ROS-sharp
            int I = uintmessage.data.Length / point_step;
            Points = new Point[I];
            byte[] byteSlice = new byte[point_step];
            for (int i = 0; i< I; i++)
            {
                Array.Copy(uintmessage.data, i * point_step, byteSlice, 0, point_step);
                Points[i] = new Point(byteSlice);
            }
			/// This section is used if you want to time between received messages. ///
			DateTime end_time = DateTime.Now;										///
            TimeSpan diff = (end_time - start_time);								///
            start_time = end_time;													///
			///////////////////////////////////////////////////////////////////////////
			// Prints the time taken for each message to be recieved.
            UnityEngine.Debug.Log("Recieved uint message image from ROS in " + diff.TotalSeconds);
    }