#!/usr/bin/env python

"""
This script used to have a great deal more code, but I deleted all the redundant
and testing code. This is the very bare bones of what this script does, it simply 
extracts the pointcloud2 data from message and send it across rosbridge in its 
smallest possible format.
"""

import rospy
from ros_bag_simulation.msg import UInt8Array
from sensor_msgs.msg import PointCloud2
import sys



uint8_msg = UInt8Array()
uint8_pub = rospy.Publisher('/compressed/uint8points', UInt8Array, queue_size=10)



def pointCloud2_sub(data):
    
    global uint8_msg
    global uint8_pub


    my_list = list(bytearray(data.data))
    uint8_msg.data = my_list
    
    uint8_pub.publish(uint8_msg)


def main():
    
    rospy.init_node('pointcloud2_sender', anonymous=True, )

    # CHANGE THE NAME OF THE SUBSCRIBER IF THE TOPIC IS DIFFERENT.
    subscriber2 = rospy.Subscriber('/camera/depth_registered/points', PointCloud2, pointCloud2_sub)

    rospy.spin()


if __name__ == '__main__':
    try:
        main()
    except rospy.ROSInterruptException:
        pass


