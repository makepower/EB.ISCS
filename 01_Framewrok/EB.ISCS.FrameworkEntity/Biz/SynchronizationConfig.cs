using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///SynchronizationConfig ：实体类
    /// </summary>	
    [Table("SynchronizationConfig")]	
	public class SynchronizationConfig
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
                public int ID {  get;set;}        
		/// <summary>
		/// UserId
        /// </summary>		
                public int UserId {  get;set;}        
		/// <summary>
		/// 0 阿里  1 京东  
        /// </summary>		
                public int PlatId {  get;set;}        
		/// <summary>
		/// 店铺的id  多个之间用逗号隔开
        /// </summary>		
                public string StoreIds {  get;set;}        
		/// <summary>
		/// SyncPeriod
        /// </summary>		
                public int SyncPeriod {  get;set;}        
		/// <summary>
		/// SyncUnit
        /// </summary>		
                public string SyncUnit {  get;set;}        
		/// <summary>
		/// EditDate
        /// </summary>		
                public DateTime EditDate {  get;set;}        
		/// <summary>
		/// Remark
        /// </summary>		
                public string Remark {  get;set;}        
		   
	}
}