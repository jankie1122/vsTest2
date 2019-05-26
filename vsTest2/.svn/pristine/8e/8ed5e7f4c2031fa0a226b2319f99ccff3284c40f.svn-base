using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取Excel
            //ExcelRead();
            //-----------------------------------------

            //写人Excel
            //ExcelWrite();

            //错账
            WriteAndExportErrorExcelMore("2018-12-11");
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        public static void ExcelRead()
        {
            //选择今天需要对账的日期
            string accountDateStr = "2018-11-28";
            DateTime date = Convert.ToDateTime(accountDateStr);

            DateTime accountStartTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            DateTime accountEndTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);


            IWorkbook workbook = null;  //新建IWorkbook对象
            string fileName = @"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\基本电子对账单测试.xlsx";
            FileStream fileStream = new FileStream(@"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\基本电子对账单测试.xlsx", FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(fileStream); //xlsx数据读入workbook
            }
            else if (fileName.IndexOf(".xls") > 0) //2003版本
            {
                workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook
            }
            ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表
            IRow row;// = sheet.GetRow(0);     //新建当前工作表行数据
            for (int i = 0; i < (sheet.LastRowNum + 1); i++)  //对工作表每一行
            {
                row = sheet.GetRow(i); //row读入第i行数据
                if (row != null)
                {
                    if (row.RowNum >= 6) //行数
                    {
                        //交易完成时间
                        DateTime completeTime = Convert.ToDateTime(row.GetCell(1).ToString());
                        bool completeTimeBool = accountStartTime <= completeTime && completeTime <= accountEndTime;
                        //string aaa = row.GetCell(4).ToString();
                        //交易类型
                        bool transTypeBool = row.GetCell(4).ToString().Equals("快捷支付消费-借")//交易类型
                            || row.GetCell(4).ToString().Equals("消费-网银支付");
                        //资金用途
                        bool useFundsBool = row.GetCell(5).ToString().Contains("www.teamaxbuy.com");
                        if ((completeTimeBool && transTypeBool && useFundsBool))
                        {
                            for (int j = 0; j < row.LastCellNum; j++)  //对工作表每一列
                            {
                                //获取表格内容
                                string cellValue = row.GetCell(j).ToString(); //获取i行j列数据
                                Console.WriteLine(cellValue);
                            }
                            Console.WriteLine("===========================================");
                        }
                    }
                }
            }
            Console.ReadLine();
            fileStream.Close();
            fileStream.Dispose();
            workbook.Close();
            workbook.Dispose();
            Console.ReadKey();
        }

        /// <summary>
        /// 写人Excel，最后上传的转账Excel
        /// </summary>
        public static void ExcelWrite()
        {
            IWorkbook workbook = null;  //新建IWorkbook对象
            string fileName = @"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\bankfile_over50K.xls";
            FileStream fileStream = new FileStream(@"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\bankfile_over50K.xls", FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(fileStream); //xlsx数据读入workbook
            }
            else if (fileName.IndexOf(".xls") > 0) //2003版本
            {
                workbook = new HSSFWorkbook(fileStream); //xls数据读入workbook
            }
            //---------------------------------------------------------------------          

            //新建xls工作簿，将模板工作簿复制到新建的工作簿
            HSSFWorkbook workbook2003 = new HSSFWorkbook();
            workbook2003 = (HSSFWorkbook)workbook;
            //获取Sheet1的工作表的名称      
            string sheet1Name = workbook2003.GetSheetAt(0).SheetName;
            HSSFSheet sheetOne = (HSSFSheet)workbook2003.GetSheet(sheet1Name);

            //边框长度
            //收款方银行
            sheetOne.SetColumnWidth(0, 3000);
            //银行卡号
            sheetOne.SetColumnWidth(1, 8500);
            //开户姓名
            sheetOne.SetColumnWidth(2, 3000);
            //开户省份
            sheetOne.SetColumnWidth(3, 2000);
            //开户城市
            sheetOne.SetColumnWidth(4, 2000);
            //开户行名称
            sheetOne.SetColumnWidth(5, 4500);
            //付款金额
            sheetOne.SetColumnWidth(6, 4000);
            //资金用途
            sheetOne.SetColumnWidth(7, 8000);

            //插入行数：6行
            for (int rowI = 0; rowI < 6; rowI++)
            {
                //获取Sheet1工作表的首行（首行索引值为2）
                HSSFRow sheetRow = (HSSFRow)sheetOne.CreateRow(2 + rowI);
                //对每一行创建8个单元格
                int cellRows = 8;
                HSSFCell[] sheetCell = new HSSFCell[cellRows];

                //边框样式
                ICellStyle style = workbook2003.CreateCellStyle();
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;


                IWorkbook myworkbook = new XSSFWorkbook();
                IDataFormat dataformat = myworkbook.CreateDataFormat();

                for (int i = 0; i < cellRows; i++)
                {
                    //为第一行创建8个单元格

                    sheetCell[i] = (HSSFCell)sheetRow.CreateCell(i);
                    sheetCell[i].CellStyle = style;

                    ////边框样式
                    //if (i == 1)
                    //{
                    //   // style.DataFormat = dataformat.GetFormat("0.000");
                    //    sheetCell[i] = (HSSFCell)sheetRow.CreateCell(i, CellType.Numeric);
                    //}
                    //else if (i == 6)
                    //{
                    //    //style.DataFormat = dataformat.GetFormat("0.00");
                    //    sheetCell[i] = (HSSFCell)sheetRow.CreateCell(i, CellType.Numeric);
                    //    sheetCell[i].CellStyle = style;
                    //}
                    //else
                    //{
                    //    sheetCell[i] = (HSSFCell)sheetRow.CreateCell(i);
                    //    sheetCell[i].CellStyle = style;
                    //}


                }
                //创建之后就可以赋值了

                //【收款方银行】不能为空，长度不能大于50，字符型，可选数据参考附录一，且必须保持一致，否则会识别为无效数据。
                sheetCell[0].SetCellValue("华夏银行");
                //【银行卡号/存折号】不能为空，长度不能大于30，数字型。                             
                sheetCell[1].SetCellValue("99112000310200220181128095843");
                //【开户姓名】不能为空，长度不能大于80，字符型。
                sheetCell[2].SetCellValue("华夏测试1");
                //【开户省份】不能为空，长度不能大于20，字符型，可选数据参考附录二，且必须保持一致，否则会识别为无效数据。
                sheetCell[3].SetCellValue("广东");
                //【开户城市】不能为空，长度不能大于20，字符型，可选数据参考附录一，且必须保持一致，否则会识别为无效数据。
                sheetCell[4].SetCellValue("广州");
                //【开户行名称】
                sheetCell[5].SetCellValue("广州分行营业部");
                //【收款金额】不能为空，长度不能大于10，允许保留2位小数，数字型；以元为单位。
                //sheetCell[6].CellStyle.DataFormat = dataformat.GetFormat("0.0");
                sheetCell[6].SetCellValue(100.23);
                //【资金用途】可以为空，长度不能大于85。
                sheetCell[7].SetCellValue("银生宝转账至华夏991电子账户");
            }

            //------------------------------------------------

            string timeStr = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            FileStream file2003 = new FileStream(@"D:\桌面\电子回单\" + timeStr + "Excel2003.xls", FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();
            workbook2003.Close();

            Console.WriteLine("完成导出");
            Console.ReadKey();
        }


        /// <summary>
        /// 错账
        /// </summary>
        public static void WriteAndExportErrorExcelMore(string checkDate)
        {
            IWorkbook workbook = null;  //新建IWorkbook对象
            string fileName = @"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\基本电子对账单.xlsx";
            FileStream fileStream = new FileStream(@"D:\天美联盟\vsTest2\KongZhiTai\ExcelDemo\ExcelTest\基本电子对账单.xlsx", FileMode.Open, FileAccess.Read);

            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(fileStream); //xlsx数据读入workbook
            }
            else //2003版本
            {
                Console.WriteLine("格式不正确");
            }
            //---------------------------------------------------------------------          
            //新建xls工作簿，将模板工作簿复制到新建的工作簿
            XSSFWorkbook workbook2007 = new XSSFWorkbook();
            workbook2007 = (XSSFWorkbook)workbook;
            //获取Sheet1的工作表的名称      
            string sheet1Name = workbook2007.GetSheetAt(0).SheetName;
            XSSFSheet sheetOne2007 = (XSSFSheet)workbook2007.GetSheet(sheet1Name);

            //第一行交易时间
            sheetOne2007.GetRow(0).Cells[1].SetCellValue(checkDate);

            //边框长度
            //交易创建时间
            sheetOne2007.SetColumnWidth(0, 6000);
            //交易完成时间
            sheetOne2007.SetColumnWidth(1, 6000);
            //订单编号
            sheetOne2007.SetColumnWidth(2, 7000);
            //交易编号
            sheetOne2007.SetColumnWidth(3, 5000);
            //交易类型
            sheetOne2007.SetColumnWidth(4, 5000);
            //资金用途
            sheetOne2007.SetColumnWidth(5, 24000);
            //收款额
            sheetOne2007.SetColumnWidth(6, 3000);
            //付款额
            sheetOne2007.SetColumnWidth(7, 3000);
            //服务费
            sheetOne2007.SetColumnWidth(8, 3000);
            //余额
            sheetOne2007.SetColumnWidth(9, 3000);
            //对方账号
            sheetOne2007.SetColumnWidth(10, 10000);
            //对方户名
            sheetOne2007.SetColumnWidth(11, 3000);
            //手续费扣除方式
            sheetOne2007.SetColumnWidth(12, 4000);

            //插入行数：6行
            for (int rowI = 0; rowI < 2; rowI++)
            {
                //获取Sheet1工作表的首行（首行索引值为6）
                XSSFRow sheetRow = (XSSFRow)sheetOne2007.CreateRow(6 + rowI);
                //对每一行创建13个单元格
                int cellRows = 13;
                XSSFCell[] sheetCell = new XSSFCell[cellRows];

                //边框样式
                ICellStyle style = workbook2007.CreateCellStyle();
                style.BorderBottom = BorderStyle.Thin;
                style.BorderLeft = BorderStyle.Thin;
                style.BorderRight = BorderStyle.Thin;
                style.BorderTop = BorderStyle.Thin;

                IWorkbook myworkbook = new XSSFWorkbook();
                IDataFormat dataformat = myworkbook.CreateDataFormat();

                for (int i = 0; i < cellRows; i++)
                {
                    //为第一行创建13个单元格
                    sheetCell[i] = (XSSFCell)sheetRow.CreateCell(i);
                    sheetCell[i].CellStyle = style;
                }

                //创建之后就可以赋值了
                sheetCell[0].SetCellValue("2018-11-28 17:57:43");
                sheetCell[1].SetCellValue("2018-11-28 18:01:10");
                sheetCell[2].SetCellValue("F2018112817573967953P1");
                sheetCell[3].SetCellValue("201811286188106");
                sheetCell[4].SetCellValue("快捷支付消费-借");
                sheetCell[5].SetCellValue("http://www.teamaxbuy.com/ShopTrade/SuccessPayReturnPage?TradeFlowID=F2018112817573967953P1");
                sheetCell[6].SetCellValue(0.10);
                sheetCell[7].SetCellValue(0.00);
                sheetCell[8].SetCellValue(0);
                sheetCell[9].SetCellValue(0.44);
                sheetCell[10].SetCellValue("E09D2CC71B4E12279305D6F0359B2DEA");
                sheetCell[11].SetCellValue("**账户");
                sheetCell[12].SetCellValue("内扣");
            }

            //------------------------------------------------

            string timeStr = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fullNameAAA = @"D:\桌面\电子回单\" + timeStr + "错账.xls";

            FileStream file2007 = new FileStream(fullNameAAA, FileMode.Create);
            workbook2007.Write(file2007);
            file2007.Close();
            file2007.Dispose();
            workbook2007.Close();



            //string sFileName = "URL";
            FileStream fileStream2 = new FileStream(fullNameAAA, FileMode.Open);
            long fileSize = fileStream2.Length;
            byte[] fileBuffer = new byte[fileSize];
            fileStream2.Read(fileBuffer, 0, (int)fileSize);
            //如果不写fileStream.Close()语句，用户在下载过程中选择取消，将不能再次下载
            fileStream2.Close();



            HttpContext curContext = HttpContext.Current;
            //HttpContext.Current.Response.ContentType = "application/octet-stream";
            curContext.Response.ContentType = "application/octet-stream";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(fullNameAAA, Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(fileBuffer);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Close();


            /*
            HttpContext.Current.Server.MapPath(@"D:\桌面\电子回单\" + timeStr + "错账.xls");                     
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;  filename="            
               + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());
            */







            //WebClient client = new WebClient();
            //client.DownloadFile(url, _directory + fileName);




            /*
            //以字符流的形式下载文件
            //Stream steamaa = new FileStream();
            //workbook2007.Write(steamaa);
            var fs = file2007;
            // FileStream fs = new FileStream();// new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;  filename="
                //+ HttpUtility.UrlEncode(fileNameaa, System.Text.Encoding.UTF8));
                + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            */

            Console.WriteLine("完成导出");
            Console.ReadKey();
        }


    }
}
