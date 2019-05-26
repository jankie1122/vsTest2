using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据流1
{
    class StreamTest
    {
        public static void StreamTest_Main()
        {
            try
            {
                ////发起请求
                //HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(urlGet);
                //wbRequest.Method = "POST";
                //wbRequest.ContentType = "application/json;charset=UTF-8";

                //byte[] load = Encoding.UTF8.GetBytes(paramJson);
                //wbRequest.ContentLength = load.Length;
                //using (Stream writer = wbRequest.GetRequestStream())
                //{
                //    writer.Write(load, 0, load.Length);
                //}

                ////接收返回包
                //string resultJson = string.Empty;
                //HttpWebResponse wbResponse = (HttpWebResponse)(await wbRequest.GetResponseAsync());

                //FileStream fs = File.OpenRead("D:\\天美联盟\\TM.SOA\\Presentation\\TM.SOA.WebApi.WxOpen\\UploadImages\\957\\11552255\\2018-07-05\\20180705160353934412.jpg"); //OpenRead
                //int filelength = 0;
                //filelength = (int)fs.Length; //获得文件长度 
                //Byte[] image = new Byte[filelength]; //建立一个字节数组 
                //fs.Read(image, 0, filelength); //按字节流读取
                //System.Drawing.Image result = System.Drawing.Image.FromStream(fs);
                //fs.Close();
                //Bitmap bit = new Bitmap(result);
                //return bit;


                //FileStream fs = File.OpenRead("D:\\天美联盟\\TM.SOA\\Presentation\\TM.SOA.WebApi.WxOpen\\UploadImages\\957\\11552255\\2018-07-05\\20180705160353934412.jpg"); //OpenRead
                //FileStream fsError = File.OpenRead("D:\\桌面\\图片测试\\123.txt");
                //StreamReader fsError = File.OpenText("D:\\桌面\\图片测试\\123.txt");
                //StreamReader sreadText = new StreamReader("D:\\桌面\\图片测试\\123.txt");
                //byte[] byteArray = File.ReadAllBytes("D:\\桌面\\图片测试\\123.txt");

                FileStream stream = File.OpenRead("D:\\天美联盟\\TM.SOA\\Presentation\\TM.SOA.WebApi.WxOpen\\UploadImages\\957\\11552255\\2018-07-05\\20180705160353934412.jpg"); //OpenRead
                //byte[] byteArray = System.Text.Encoding.Default.GetBytes("{\"errcode\":61004,\"errmsg\":\"access clientip is not registered hint: [aHCZjA05601518]\"}");
                //MemoryStream stream = new MemoryStream(byteArray);



                Stream streamRead = new MemoryStream();
                using (Stream responseStream = stream)
                {
                    //注释代码保留，这里使用了responseStream会影响该字段转换为byte []，原因不详。
                    //如果请求成功会直接返回数据流，
                    //如果请求失败会返回Json{"errcode":61004,"errmsg":"access clientip is not registered hint: [aHCZjA05601518]"}
                    //{"errcode":61004,"errmsg":"access clientip is not registered hint: [aHCZjA05601518]"}

                    //JsObject result = JsonObject.Parse(stream);

                    //Stream streamImg = new MemoryStream();
                    //streamImg = responseStream;



                    streamRead = stream;

                    //将数据流转为byte[]
                    List<byte> bytes = new List<byte>();
                    int temp = responseStream.ReadByte();

                    if (temp == -1)
                    {
                        Console.WriteLine("错误");
                    }


                    while (temp != -1)
                    {
                        bytes.Add((byte)temp);
                        temp = responseStream.ReadByte();
                    }
                    byte[] mg = bytes.ToArray();



                    StreamReader sread = new StreamReader(streamRead);
                    string result = sread.ReadToEnd();
                    //JsonObject resultObj = JsonObject.Parse(result);
                    try
                    {
                        Dictionary<string, string> dicResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }




                    //实例化一个文件流--->与写入文件相关联
                    FileStream fs2 = new FileStream("D:\\桌面\\图片测试\\" + DateTime.Now.ToString("yyMMddHHmmSSfff") + ".jpg", FileMode.Create);
                    byte[] data = mg;

                    //开始写入
                    fs2.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                    fs2.Flush();
                    fs2.Close();

                    //stream = new MemoryStream(mg);
                    //SaveFileDialog sf = new SaveFileDialog();
                    //实例化一个文件流--->与写入文件相关联
                    //FileStream fs2 = new FileStream("D:\\桌面\\图片测试\\" + DateTime.Now.ToString("yyMMddHHmmssfff")+".jpg", FileMode.Create);
                    //获得字节数组
                    //byte[] data = new UTF8Encoding().GetBytes(bytes);
                    //byte[] data = mg;                     
                    ////开始写入
                    //fs2.Write(data, 0, data.Length);               
                    ////清空缓冲区、关闭流
                    //fs2.Flush();
                    //fs2.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            Console.ReadKey();

        }
    }
}
