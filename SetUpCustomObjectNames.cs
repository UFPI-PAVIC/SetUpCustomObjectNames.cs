using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.Control;

public class SetUpCustomObjectNames : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject base_footprint;
    private GameObject base_link;
    private GameObject base_scan;
    private GameObject imu_link;
    private GameObject wheel_right_link;
    private GameObject wheel_left_link;
    private string turtlebot_component_name;
    void Awake()
    {
        SetObjectNames();
        SetTopics();
    }

    /// <summary>
    /// Assigns individual cmd_vel and scan topics to each robot.
    /// </summary>
    void SetTopics(){
        // cmd_vel topic
        char robot_num = turtlebot_component_name[turtlebot_component_name.Length-1];
        GetComponent<AGVController>().topic = "turtlesim" + robot_num + "/turtle1/cmd_vel";

        // scan topic
        base_footprint = gameObject.transform.GetChild(1).gameObject;
        base_link = base_footprint.transform.GetChild(2).gameObject;
        base_scan = base_link.transform.GetChild(2).gameObject;

        base_scan.GetComponent<LaserScanSensor>().topic = "/scan_" + robot_num;
        base_scan.GetComponent<LaserScanSensor>().FrameId = "base_scan_" + robot_num;

    }

    /// <summary>
    /// Assigns individual names to the relevant link components so that each robot has a specific branch in the tf tree. 
    /// </summary>
    void SetObjectNames(){

        turtlebot_component_name = name; 

        base_footprint = gameObject.transform.GetChild(1).gameObject;
        
        base_link = base_footprint.transform.GetChild(2).gameObject;
        
        base_scan = base_link.transform.GetChild(2).gameObject;
        imu_link = base_link.transform.GetChild(3).gameObject;
        wheel_left_link = base_link.transform.GetChild(4).gameObject;
        wheel_right_link = base_link.transform.GetChild(5).gameObject;

        char robot_num = turtlebot_component_name[turtlebot_component_name.Length-1];

        base_footprint.name += "_" + robot_num;
        base_link.name += "_" + robot_num;
        base_scan.name += "_" + robot_num;
        imu_link.name += "_" + robot_num;
        wheel_left_link.name += "_" + robot_num;
        wheel_right_link.name += "_" + robot_num;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
