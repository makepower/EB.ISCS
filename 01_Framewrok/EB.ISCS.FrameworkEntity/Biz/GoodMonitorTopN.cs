using Dapper;
using System;

namespace Maticsoft.Model
{
    /// <summary>
    ///首页监控指标信息 ：实体类
    /// </summary>	
    [Table("GoodMonitorTopN")]	
	public class GoodMonitorTopN
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
		/// Unit
        /// </summary>		
                public string Unit {  get;set;}        
		/// <summary>
		/// StatisDate
        /// </summary>		
                public DateTime StatisDate {  get;set;}        
		/// <summary>
		/// 参考 静态指标   类目枚举
        /// </summary>		
                public string StatisType {  get;set;}        
		/// <summary>
		/// 0: 最近7天  1: 最近30天   2: 最近90天
        /// </summary>		
                public int StatisPeriodType {  get;set;}        
		/// <summary>
		/// Remark
        /// </summary>		
                public string Remark {  get;set;}        
		   
	}
}