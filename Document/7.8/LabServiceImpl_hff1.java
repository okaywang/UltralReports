package com.shuto.webservice.lab.server;

import java.io.StringReader;
import java.sql.Connection;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.jdom.Document;
import org.jdom.Element;
import org.jdom.input.SAXBuilder;
import org.xml.sax.InputSource;

import com.shuto.webservice.lab.server.db.Db;
import com.shuto.webservice.lab.utils.Log;
import com.shuto.webservice.lab.utils.Server;
/**
 * 2014comDatabase.mdb
 * @author lxh
 *适用于AutoMac.mdb 文件  
 *水分、灰分、挥发分分析仪1
 */
public class LabServiceImpl_hff1 implements LabService {
	
	public String  addLab(String strXML,String SampleClass) throws Exception {
		int count = 0 ;  
		Connection conn = null ; 
		Statement stmt =null ; 
		try{
			 conn = Db.getConnection();  //得到数据库连接 
			 conn.setAutoCommit(false);  
			 stmt = conn.createStatement() ; 
			 List<Map<String, String >> scales =  this.getDataList(strXML);
			for (int i = 0; i < scales.size(); i++) {
				Map<String, String> scale = scales.get(i);
				///
				String sql = "insert into ST_HY_TESTRESULT(" + "createdate,"+
				"SerialNumber,ObjCode,SampleName,tsDate,EmptyGGWeight,AddColeWeight,"+
				"ColeWeight,Wcanzhong,Wshizhong,Jiaozhahao,Mad,Acanmaozhong,Acanzhong,"+
				"Aad,Ad,VEmptyGGWeight,VAddColeWeight,VWeight,Vcanzhong,Vshizhong,Vad,"+
				"Vd,Vdaf,Qbad,Had,Fcad,Fcd,Fcdaf,CO2ad,CMad,Mar,QGrad,QNetar,CountNumber,Memo," +
				"ST_HY_TESTRESULTID,HASLD,YSSJ,SCDATE,SampleClass)" +
				"values (to_date(" + scale.get("createdate")
						+ ",'yyyy-mm-dd hh24:mi:ss'),"
						+ scale.get("SerialNumber") + ","
						+ scale.get("ObjCode") + ","
						+ scale.get("SampleName") + 
						",to_date(" + scale.get("Date")
						+ ",'yyyy-mm-dd hh24:mi:ss'),"
						+ scale.get("EmptyGGWeight") + ","
						+ scale.get("AddColeWeight") + ","
						+ scale.get("ColeWeight") + ","
						+ scale.get("Wcanzhong") + ","
						+ scale.get("Wshizhong") + ","
//						+ scale.get("SampleClass") + ","
						+ scale.get("Jiaozhahao") + ","
						+ scale.get("Mad") + ","
						+ scale.get("Acanmaozhong") + ","
						+ scale.get("Acanzhong") + ","
						+ scale.get("Aad") + ","
						+ scale.get("Ad") + ","
						+ scale.get("VEmptyGGWeight") + ","
						+ scale.get("VAddColeWeight") + ","
						+ scale.get("Vweight") + ","
						+ scale.get("Vcanzhong") + ","
						+ scale.get("Vshizhong") + ","
						+ scale.get("Vad") + ","
						+ scale.get("Vd") + ","
						+ scale.get("Vdaf") + ","
						+ scale.get("Qbad") + ","
						+ scale.get("Had") + ","
						+ scale.get("Fcad") + ","
						+ scale.get("Fcd") + ","
						+ scale.get("Fcdaf") + ","
						+ scale.get("CO2ad") + ","
						+ scale.get("Cmad") + ","
						+ scale.get("Mar") + ","
						+ scale.get("Qgrad") + ","
						+ scale.get("Qnetar") + ","
						+ scale.get("CountNumber") + ","
//						+ scale.get("Operator") + ","
						+ scale.get("Memo")
						+",ST_HY_TESTRESULTIDSEQ.NEXTVAL,1,'原始数据',sysdate,'"+SampleClass+"')";
				
				count ++ ; 
				
				stmt.addBatch(sql);  
				System.out.println("=="+sql);
			}
			stmt.executeBatch()  ; 
			conn.commit() ;  
			
		}catch(Exception ex){
			ex.printStackTrace(); 
			Log.writelog(ex,Server.serverpath); 
			conn.rollback() ;  
			throw ex ; 
		}finally{
			try{
				stmt.close() ; 
				conn.close() ; 
			}catch(Exception e){
				e.printStackTrace();  
				throw e  ; 
			}
			
		}
		return String.valueOf(count);  //返回成功的条数
	}
	
	
	public List<Map<String, String >> getDataList(String strXML) throws Exception {

		StringReader reader = new StringReader(strXML);
		InputSource source = new InputSource(reader);
		SAXBuilder saxBuilder = new SAXBuilder();
		Document document = saxBuilder.build(source);
		Element rootElt = document.getRootElement(); // 获取XML的根元素 【datas节点】
		List<Element> datas = rootElt.getChildren();// 获取XML的根元素 的子节点 【data节点】
		
		List<Map<String, String>>  mapList = new ArrayList<Map<String,String>>();
		
		for (int i = 0; i < datas.size(); i++) {
			Element data = datas.get(i); // 获取Data节点
			
			
			
			String createdate = data.getChild("createdate").getText();// 创建时间
			String SerialNumber1 = data.getChild("SerialNumber").getText();// 样品编号
			String SerialNumber=SerialNumber1.replace(" ","");
			
			String  ObjCode= data.getChild("ObjCode").getText();//
			String  SampleName1= data.getChild("SampleName").getText().trim();//
			String  SampleName = SampleName1.replace(" ","");
			String  sDate= data.getChild("Date").getText();//
			String  EmptyGGWeight= data.getChild("EmptyGGWeight").getText();//
			String  AddColeWeight= data.getChild("AddColeWeight").getText();//
			String  ColeWeight= data.getChild("ColeWeight").getText();//
			String  Wcanzhong= data.getChild("Wcanzhong").getText();//
			String  Wshizhong= data.getChild("Wshizhong").getText();//
//			String  SampleClass= data.getChild("SampleClass").getText();//
			String  Jiaozhahao= data.getChild("Jiaozhahao").getText();//
			String  Mad= data.getChild("Mad").getText();//
			String  Acanmaozhong= data.getChild("Acanmaozhong").getText();//
			String  Acanzhong= data.getChild("Acanzhong").getText();//
			String  Aad= data.getChild("Aad").getText();//
			String  Ad= data.getChild("Ad").getText();//
			String  VEmptyGGWeight= data.getChild("VEmptyGGWeight").getText();//
			String  VAddColeWeight= data.getChild("VAddColeWeight").getText();//
			String  VWeight= data.getChild("VWeight").getText();//
			String  Vcanzhong= data.getChild("Vcanzhong").getText();//
			String  Vad= data.getChild("Vad").getText();//
			String  Vd= data.getChild("Vd").getText();//
			String  Vdaf= data.getChild("Vdaf").getText();//
			String  Qbad= data.getChild("Qbad").getText();//
			String  Had= data.getChild("Had").getText();//
			String  Fcad= data.getChild("Fcad").getText();//
			String  Fcd= data.getChild("Fcd").getText();//
			String  Fcdaf= data.getChild("Fcdaf").getText();//
			String  CO2ad= data.getChild("CO2ad").getText();//
			String  CMad= data.getChild("CMad").getText();//
			String  Mar= data.getChild("Mar").getText();//
			String  QGrad= data.getChild("QGrad").getText();//
			String  QNetar= data.getChild("QNetar").getText();//
			String  CountNumber= data.getChild("CountNumber").getText();//
//			String  Operator= data.getChild("Operator").getText();//
			String  Memo= data.getChild("Memo").getText();//
			
			
			Map<String, String> map = new LabMap();
			/////
			map.put("createdate", createdate);
			map.put("SerialNumber", SerialNumber); //样品编号
			map.put("ObjCode", ObjCode); //坩埚号
			map.put("SampleName", SampleName); //样品名称
			map.put("Date", sDate); //测试时间
			map.put("EmptyGGWeight", EmptyGGWeight); //水灰空坩埚重
			map.put("AddColeWeight",  AddColeWeight); //水灰加煤后重
			map.put("ColeWeight",  ColeWeight); //水灰煤样重
			map.put("Wcanzhong",  Wcanzhong); //水残重
			map.put("Wshizhong",  Wshizhong); //水失重
//			map.put("SampleClass",  SampleClass); //煤种
			map.put("Jiaozhahao",  Jiaozhahao); //焦渣号
			map.put("Mad",  Mad); //水分含量
			map.put("Acanmaozhong",  Acanmaozhong); //灰毛残重
			map.put("Acanzhong",  Acanzhong); //灰残重
			map.put("Aad",  Aad); //空干基灰分
			map.put("Ad",  Ad); //干基灰分
			map.put("VEmptyGGWeight",  VEmptyGGWeight); //挥发分空坩埚重
			map.put("VAddColeWeight",  VAddColeWeight); //挥发分加煤后重
			map.put("VWeight",  VWeight); //挥发分煤样重
			map.put("Vcanzhong",  Vcanzhong); //挥发分残重
			map.put("Vshizhong",  Vcanzhong); //挥失重
			map.put("Vad",  Vad); //空干基挥发分
			map.put("Vd",  Vd); //干基挥发分
			map.put("Vdaf",  Vdaf); //干燥无灰基
			map.put("Qbad",  Qbad); //热值
			map.put("Had",  Had); //氢含量
			map.put("Fcad",  Fcad); //空干基固定碳含量
			map.put("Fcd",  Fcd); //干基固定碳含量
			map.put("Fcdaf",  Fcdaf); //干燥无灰基固定碳含量
			map.put("CO2ad",  CO2ad); //二氧化碳含量
			map.put("CMad",  CMad); //灰渣可燃物
			map.put("Mar",  Mar); //全水分
			map.put("QGrad",  QGrad); //高位热值
			map.put("QNetar",  QNetar); //低位热值
			map.put("CountNumber",  CountNumber); //记录条数
//			map.put("Operator",  Operator); //测试者
			map.put("Memo",  Memo); //备注
			
			mapList.add(map);
			
		}
		return mapList;
	}
	
}
