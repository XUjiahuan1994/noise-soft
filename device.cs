using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ps5000example
{
    public abstract class Device                //定义一个Device类，由各个类型的设备继承
    {
        public String name;

        public int interval;     //用于存储每次轮询的时间间隔

        public void setName(String name)
        {
            this.name = name;
        }


        public abstract void sendCmd(byte[] cmd);     //发送命令

        public abstract byte[] readData();        //接收返回的数据

        public abstract void storeData();         //存储数据

        public abstract void readDataPolling();

        public abstract void restart();

        public abstract void resetZero();


    }
}
