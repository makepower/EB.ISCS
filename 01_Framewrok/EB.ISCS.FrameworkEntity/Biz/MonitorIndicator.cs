using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控指标信息 ：实体类
    /// </summary>	
    [Table("MonitorIndicator")]	
	public class MonitorIndicator
	{
   		     
      	/// <summary>
		/// Id
        /// </summary>		
                [Key]
		        public int Id {  get;set;}        
		/// <summary>
		/// Name
        /// </summary>		
                public string Name {  get;set;}        
		/// <summary>
		/// ShortName
        /// </summary>		
                public string ShortName {  get;set;}        
		/// <summary>
		/// value
        /// </summary>		
                public decimal value {  get;set;}        
		/// <summary>
		/// StatisDate
        /// </summary>		
                public DateTime StatisDate {  get;set;}        
		/// <summary>
		/// 环比
        /// </summary>		
                public decimal mom {  get;set;}        
		/// <summary>
		/// 同比指数
        /// </summary>		
                public decimal yoy {  get;set;}        
		/// <summary>
		/// Unit
        /// </summary>		
                public string Unit {  get;set;}        
		/// <summary>
		/// Remark
        /// </summary>		
                public string Remark {  get;set;}        
		   
	}
}