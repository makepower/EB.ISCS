using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///物流跟踪信息 ：实体类
    /// </summary>	
    [Table("WayBillTraceInfo")]	
	public class WayBillTraceInfo
	{
   		     
      	/// <summary>
		/// Id
        /// </summary>		
                [Key]
		        public int Id {  get;set;}        
		/// <summary>
		/// LogisticId
        /// </summary>		
                public int LogisticId {  get;set;}        
		/// <summary>
		/// AcceptTime
        /// </summary>		
                public string AcceptTime {  get;set;}        
		/// <summary>
		/// AcceptStation
        /// </summary>		
                public string AcceptStation {  get;set;}        
		/// <summary>
		/// SyncDate
        /// </summary>		
                public DateTime SyncDate {  get;set;}        
		/// <summary>
		/// Remark
        /// </summary>		
                public string Remark {  get;set;}        
		   
	}
}