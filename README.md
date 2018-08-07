# PointCloud2-Sender
The ROS and Unity3D code used to (hopefully) increase the transmission of pointcloud 2 messages from ROSbridge to C#

## Installation for ROS
1. Clone or copy the [ROS/pointcloud2_sender](ROS/pointcloud2_sender) directory into your "home/username/catkin_ws/scr" directory.
2. Navigate back to "home/username/catkin_ws" directory and execute ''' catkin_make ''' command then ''' source devel/setup.bash ''' commands and the packages should build.
3. Run the ros package by type in the terminal '''roslaunch pointcloud2_sender pointcloud2_sender.launch'''.

## Installation for Unity3D in Windows
1. Download ** version 1.2 release ** of the ros-sharp source code (also ensure you have imported into Unity the 1.2v compiled assets), the 1.2v source code can be downloaded [here](https://github.com/siemens/ros-sharp/tree/v1.2)
2. Clone or copy the [Unity3D](Unity3D) directory into your windows machine.
3. Copy the file [Message.cs](Unity3D/Message.cs) file into your "ros-sharp-1.2/RosBridgeClient" folder, overriding the original Message.cs file.
4. Open and build a new RosBridge.dll file by opening RosBridge.sln in the same folder in Visual Studio 12 or above. 
5. Once you've built RosBridge.sln project, navigate to "ros-sharp-1.2/RosBridgeClient/bin/Release(or Debug)" and copy "rosBridgeClient.dll" into your Unity project under "\Assets\RosSharp\Plugins" overriding the existing RosBridge.dll file there.
6. Open [PointCloudReciever.cs](Unity3D/PointCloudReciever.cs) using your favourite text editor, and follow the code copying and pasting instruction in that file.

You will obviously have to edit your PointCloudReciever.cs file in order to fully utilise the new message. Hopefully you'll receive point cloud data faster now. 

