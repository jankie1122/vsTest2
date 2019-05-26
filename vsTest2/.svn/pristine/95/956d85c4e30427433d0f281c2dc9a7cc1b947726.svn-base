using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取服务器绝对路径
            //string serverPath = AppDomain.CurrentDomain.BaseDirectory;          
            //XDocument document = XDocument.Load(serverPath + "/Controllers/Shop/101090商户信息查询.xml");

            SubAccount sub = new SubAccount();
            sub.TradeMemBerName = "交易会员名称";
            sub.Currency = "币种";
            sub.SubAcc = "132456";

            /*
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(sub.GetType());
                serializer.Serialize(sw, sub);
                sw.Close();
                //这里打印出来包括了xml头标签
                Console.WriteLine(sw.ToString());
            }
            */

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.AppendLine("<CPMB2B>");
            sb.AppendLine("<MessageData>");
            sb.AppendLine("<Base>");
            sb.AppendLine("<Version>1.0</Version>");
            sb.AppendLine("<SignFlag>0</SignFlag>");
            sb.AppendLine("<SeverModel>3</SeverModel>");
            sb.AppendLine("</Base>");
            sb.AppendLine("<ReqHeader>");
            sb.AppendLine("<ClientTime>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</ClientTime>");
            sb.AppendLine("<MerchantNo>" + 12000085 + "</MerchantNo>");
            sb.AppendLine("<TransCodeId>" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(100000, 999999) + "</TransCodeId>");
            sb.AppendLine("<TransCode>" + 100000 + "</TransCode>");
            sb.AppendLine("</ReqHeader>");
            sb.AppendLine("<DataBody>");
            foreach (var propertyInfo in sub.GetType().GetProperties())
            {
                sb.AppendLine(string.Format("<{0}>{1}</{0}>", propertyInfo.Name, propertyInfo.GetValue(sub, null)));
            }
            sb.AppendLine("</DataBody>");
            sb.AppendLine("</MessageData>");
            sb.AppendLine("</CPMB2B>");


            Console.WriteLine(sb);


            //将XML转换成实体类

            StringBuilder sbRes = new StringBuilder();
            sbRes.AppendLine("<?xml version = \"1.0\" encoding =\"GBK\"?>");
            sbRes.AppendLine("<CPMB2B>");
            sbRes.AppendLine("<MessageData>");//----MessageData
            sbRes.AppendLine("<Base>");//----Base
            sbRes.AppendLine("<Version>1.0</Version>");
            sbRes.AppendLine("<SignFlag>1</SignFlag>");
            sbRes.AppendLine("<SeverModel>3</SeverModel>");
            sbRes.AppendLine("</Base>");
            sbRes.AppendLine("<ResHeader>");//----ResHeader
            sbRes.AppendLine("<TransCodeId>25637b8fb4a04faf</TransCodeId>");
            sbRes.AppendLine("<TransCode>101090</TransCode>");
            sbRes.AppendLine("<Status>");
            sbRes.AppendLine("<Code>000000</Code>");//sbRes.AppendLine("<Code>BPI052</Code>");
            sbRes.AppendLine("<Message>日期或时间不合法</Message>");
            sbRes.AppendLine("</Status>");
            sbRes.AppendLine("</ResHeader>");
            sbRes.AppendLine("<DataBody>");//----DataBody
            sbRes.AppendLine("<MerchantNo>12111151</MerchantNo>");
            sbRes.AppendLine("<CompanyProperty>企业性质</CompanyProperty>");
            sbRes.AppendLine("<CreadScope></CreadScope>");
            sbRes.AppendLine("<BusinesLicence></BusinesLicence>");
            sbRes.AppendLine("<CommercialAddr></CommercialAddr>");
            sbRes.AppendLine("<ChinaCode></ChinaCode>");
            sbRes.AppendLine("<CommercialUrl></CommercialUrl>");
            sbRes.AppendLine("<LegalBusinessName></LegalBusinessName>");
            sbRes.AppendLine("<LegalPapersType></LegalPapersType>");
            sbRes.AppendLine("<LegalPapersCode></LegalPapersCode>");
            sbRes.AppendLine("<Contact></Contact>");
            sbRes.AppendLine("<ContactPhone></ContactPhone>");
            sbRes.AppendLine("<FaxCode></FaxCode>");
            sbRes.AppendLine("<EmailAddr></EmailAddr>");
            sbRes.AppendLine("<BusinessIp></BusinessIp>");
            sbRes.AppendLine("<State></State>");
            sbRes.AppendLine("<CommercialEndDay></CommercialEndDay>");
            sbRes.AppendLine("<InterUrl></InterUrl>");
            sbRes.AppendLine("<CusManagerCode></CusManagerCode>");
            sbRes.AppendLine("<CusManagerArea></CusManagerArea>");
            sbRes.AppendLine("<CusManagerName></CusManagerName>");
            sbRes.AppendLine("<IsMessagerSever></IsMessagerSever>");
            sbRes.AppendLine("<TradeMessagerPhone></TradeMessagerPhone>");
            sbRes.AppendLine("<IsStopOutMoney></IsStopOutMoney>");
            sbRes.AppendLine("<IsStopInMoney></IsStopInMoney>");
            sbRes.AppendLine("<IsMoneyModifyState></IsMoneyModifyState>");
            sbRes.AppendLine("<LinkWay></LinkWay>");
            sbRes.AppendLine("<SettleAccountRatio></SettleAccountRatio>");
            sbRes.AppendLine("<SettleMemoRatio></SettleMemoRatio>");
            sbRes.AppendLine("<InOutOuathSign></InOutOuathSign >");
            sbRes.AppendLine("<SubAccount></SubAccount>");
            sbRes.AppendLine("<OutComeAccount></OutComeAccount>");
            sbRes.AppendLine("<OutComeAccountName></OutComeAccountName>");
            sbRes.AppendLine("<OutComeAccountBank></OutComeAccountBank>");
            sbRes.AppendLine("<OutComeAccountIDType></OutComeAccountIDType>");
            sbRes.AppendLine("<OutComeAccountIDCode></OutComeAccountIDCode>");
            sbRes.AppendLine("</DataBody>");
            sbRes.AppendLine("</MessageData>");
            sbRes.AppendLine("</CPMB2B>");


            XMLParseToObj<BusinessInfoInquiryResponse>(sbRes.ToString());



            Console.ReadKey();

        }



        public static void XMLParseToObj<T>(string xmlStr)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //字符串赋值给xml
            xmlDoc.LoadXml(xmlStr);
            //选择节点
            //XmlNodeList resHeaderNoteList = xmlDoc.SelectNodes("/CPMB2B/MessageData/ResHeader");
            //if (resHeaderNoteList != null)
            //{
            //    foreach (XmlNode resHeaderNode in resHeaderNoteList)
            //    {
            //        //拿到ResHeader节点转换成xml,xml包括了ResHeader
            //        XmlElement xeResHeader = (XmlElement)resHeaderNode;
            //        //获取ResHeader节点下的所有子节点
            //        XmlNodeList xnResHeaderChildList = xeResHeader.ChildNodes;
            //        //遍历子节点
            //        //foreach (XmlNode xnResHeaderChild in xnResHeaderChildList)

            foreach (XmlNode xnResHeaderChild in xmlDoc.SelectSingleNode("/CPMB2B/MessageData/ResHeader"))
            {
                if ("TransCodeId".Equals(xnResHeaderChild.Name))
                {
                    Console.WriteLine(xnResHeaderChild.Name + "----" + xnResHeaderChild.InnerText);
                }
                else if ("TransCode".Equals(xnResHeaderChild.Name))
                {
                    Console.WriteLine(xnResHeaderChild.Name + "----" + xnResHeaderChild.InnerText);
                }
                else if ("Status".Equals(xnResHeaderChild.Name))
                {
                    //Console.WriteLine(xnResHeaderChild.Name + "----" + xnResHeaderChild.InnerText);
                    ////将Status节点转换成xml,xml包括了Status
                    //XmlElement xeStatus = (XmlElement)xnResHeaderChild;
                    ////拿到Status节点下的所有子节点
                    //XmlNodeList xnStatusChildList = xeStatus.ChildNodes;
                    foreach (XmlNode xnStatusChild in xmlDoc.SelectSingleNode("/CPMB2B/MessageData/ResHeader/Status"))
                    {
                        if ("Code".Equals(xnStatusChild.Name))
                        {
                            if (!("000000").Equals(xnStatusChild.InnerText))
                            {
                                //打印错误消息
                                Console.WriteLine("错误代码" + "----" + xnStatusChild.InnerText);
                                XmlNode xnMessageList = xmlDoc.SelectSingleNode("/CPMB2B/MessageData/ResHeader/Status/Message");
                                //foreach (XmlNode xnMessage in xnMessageList)
                                //{
                                //    Console.WriteLine("错误消息" + "----" + xnMessage.InnerText);
                                //}
                                Console.WriteLine("错误消息" + "----" + xnMessageList.InnerText);
                            }
                            else
                            {
                                string className = typeof(T).Name;
                                StringBuilder sbNew = new StringBuilder();
                                sbNew.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\"?>");
                                sbNew.AppendLine("<" + className + ">");
                                //打印正确返回对象
                                XmlNode xnDataBody = xmlDoc.SelectSingleNode("/CPMB2B/MessageData/DataBody");
                                foreach (XmlNode xnDataBody2 in xnDataBody.ChildNodes)
                                {
                                    sbNew.AppendLine(string.Format("<{0}>{1}</{0}>", xnDataBody2.Name, xnDataBody2.InnerText, xnDataBody2.Name));
                                }
                                sbNew.AppendLine("</" + className + ">");

                                XmlSerializer serializer = new XmlSerializer(typeof(T));
                                using (StringReader reader = new StringReader(sbNew.ToString()))
                                {
                                    T responseEntity = (T)serializer.Deserialize(reader);
                                }
                            }
                        }
                    }
                }
            }
            //  }
            //}
        }

    }

    public class BaseResponse
    {
        public int Status { get; set; }
        public string Msg { get; set; }
    }

    public class SubAccount
    {
        /// <summary>
        /// 交易会员名称
        /// </summary>
        public string TradeMemBerName { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 子账号
        /// </summary>
        public string SubAcc { get; set; }
        /*
        /// <summary>
        /// 摊位号
        /// </summary>
        public string BoothNo { get; set; }
        /// <summary>
        /// 交易会员级别
        /// </summary>
        public string TradeMemBerGrade { get; set; }
        /// <summary>
        /// 上级会员代码
        /// </summary>
        public string GradeCode { get; set; }
        /// <summary>
        /// 交易会员性质0-企业1 - 个人
        /// </summary>
        public string TradeMemberProperty { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string ContactAddr { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PapersType { get; set; }
        /// <summary>
        /// 证件代码
        /// </summary>
        public string PapersCode { get; set; }
        /// <summary>
        /// 是否需要短信通知
        /// </summary>
        public string IsMessager { get; set; }
        /// <summary>
        /// 短信通知手机
        /// </summary>
        public string MessagePhone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 备注1
        /// </summary>
        public string Remark1 { get; set; }
        /// <summary>
        /// 备注2
        /// </summary>
        public string Remark2 { get; set; }
        /// <summary>
        /// 备注3
        /// </summary>
        public string Remark3 { get; set; }
        /// <summary>
        /// 备注4
        /// </summary>
        public string Remark4 { get; set; }
        /// <summary>
        /// 备注5
        /// </summary>
        public string Remark5 { get; set; }
        */
    }

    /// <summary>
    /// 101090商户信息查询，应答报文
    /// </summary>
    public class BusinessInfoInquiryResponse
    {
        /// <summary>
        /// 商户代码 8 是
        /// </summary>
        public string MerchantNo { get; set; }

        /// <summary>
        /// 企业性质 80 是
        /// </summary>
        public string CompanyProperty { get; set; }

        /// <summary>
        /// 经营范围 128 否
        /// </summary>
        public string CreadScope { get; set; }

        /// <summary>
        /// 营业执照 64 是
        /// </summary>
        public string BusinesLicence { get; set; }

        /// <summary>
        /// 商户地址128 是
        /// </summary>
        public string CommercialAddr { get; set; }

        /// <summary>
        /// 邮政编码 8 是
        /// </summary>
        public string ChinaCode { get; set; }

        /// <summary>
        /// 商户主页URL 128 否
        /// </summary>
        public string CommercialUrl { get; set; }

        /// <summary>
        /// 法人代表姓名 64 是
        /// </summary>
        public string LegalBusinessName { get; set; }

        /// <summary>
        /// 法人代表证件类型 2 是
        /// </summary>
        public string LegalPapersType { get; set; }

        /// <summary>
        /// 法人代表身份证件代码 30 否
        /// </summary>
        public string LegalPapersCode { get; set; }

        /// <summary>
        /// 联系人 25 否
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系电话 25 否
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 传真号码 24 否
        /// </summary>
        public string FaxCode { get; set; }

        /// <summary>
        /// 邮箱地址 40 否
        /// </summary>
        public string EmailAddr { get; set; }

        /// <summary>
        /// 商户交易平台IP地址   20 否
        /// </summary>
        public string BusinessIp { get; set; }

        /// <summary>
        /// 状态 1 是  
        /// 0：正常，1：停用
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 商户日切日期（YYYYMMDD） 8 是
        /// </summary>
        public string CommercialEndDay { get; set; }

        /// <summary>
        /// 接口URL 200 否
        /// </summary>
        public string InterUrl { get; set; }

        /// <summary>
        /// 客户经理代码 100 否
        /// </summary>
        public string CusManagerCode { get; set; }

        /// <summary>
        /// 客户经理地区号 100 否
        /// </summary>
        public string CusManagerArea { get; set; }

        /// <summary>
        /// 客户经理姓名 100 否
        /// </summary>
        public string CusManagerName { get; set; }

        /// <summary>
        /// 是否需要短信服务 1 是 
        /// 1-需要 2-不需要
        /// </summary>
        public string IsMessagerSever { get; set; }

        /// <summary>
        /// 交易平台短信通知手机号码 20 是
        /// </summary>
        public string TradeMessagerPhone { get; set; }

        /// <summary>
        /// 出金暂停标志 1 是 
        /// 0:正常，1：交易市场出金暂停，2：交易商出金暂停，3：全部暂停
        /// </summary>
        public string IsStopOutMoney { get; set; }

        /// <summary>
        /// 入金暂停标志 1 是
        /// 0:正常 1：暂停
        /// </summary>
        public string IsStopInMoney { get; set; }

        /// <summary>
        /// 资金变动短信开关 1 是
        /// 1;允许发送短信（默认）；0：不发送短信
        /// </summary>
        public string IsMoneyModifyState { get; set; }

        /// <summary>
        /// 接入方式 1 是
        /// 1-互联网 2-专线
        /// </summary>
        public string LinkWay { get; set; }

        /// <summary>
        /// 结算费商户占比 8 是
        /// %
        /// </summary>
        public string SettleAccountRatio { get; set; }

        /// <summary>
        /// 结算费交易会员占比 8 是
        /// %
        /// </summary>
        public string SettleMemoRatio { get; set; }

        /// <summary>
        /// 出入金账户授权标志 1 是
        /// 0-不授权 1-授权
        /// </summary>
        public string InOutOuathSign { get; set; }

        /// <summary>
        /// 子帐号 32 是
        /// </summary>
        public string SubAccount { get; set; }

        /// <summary>
        /// 出入金帐号 32 是
        /// </summary>
        public string OutComeAccount { get; set; }

        /// <summary>
        /// 出入金账户名 64 是
        /// </summary>
        public string OutComeAccountName { get; set; }

        /// <summary>
        /// 出入金开户行 64 是
        /// </summary>
        public string OutComeAccountBank { get; set; }

        /// <summary>
        /// 出入金账户证件类型 2 是
        /// </summary>
        public string OutComeAccountIDType { get; set; }

        /// <summary>
        /// 出入金账户证件号码 30 是
        /// </summary>
        public string OutComeAccountIDCode { get; set; }
    }

}
