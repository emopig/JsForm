using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// JsonServer 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class JsonServer : System.Web.Services.WebService
{

    public JsonServer()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetBlockJson(int frmId,int blkId)
    {
        string jsonText = "[{'a':'aaa','b':'bbb','c':'ccc'},{'a':'aaa2','b':'bbb2','c':'ccc2'}]";
        JArray jArray = (JArray)JsonConvert.DeserializeObject(jsonText);
        JObject jObject = (JObject)jArray[1];
        string sql = (string)jObject["sql"];

        Database db = new Database();
        OracleDataReader reader = db.returnSqlReader(sql);
        return reader.convert2json;
    }

}
