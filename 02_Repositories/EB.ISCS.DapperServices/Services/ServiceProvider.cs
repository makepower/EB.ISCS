using System;
using System.Collections.Generic;
using System.Reflection;

namespace EB.ISCS.DapperServices.Services
{

    /// <summary>
    /// 服务提供商
    /// </summary>
    public  class ServiceProvider : IEBServiceProvider
    {
        
        private readonly Dictionary<string, ServiceDescriptor> _dict;

        public ServiceProvider()
        {
            _dict = new Dictionary<string, ServiceDescriptor>();
        }
        /// <summary>
        /// 根据类型返回服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        object IServiceProvider.GetService(Type serviceType)
        {
            var sName = serviceType.Name;
            return GetService(sName);
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="typeInterface">类接口类型</param>
        /// <param name="typeClass">实体类类型</param>
        /// <param name="bSystem">是否系统数据库</param>
        /// <param name="bSingleton">是否单例</param>
        public void RegisterService(Type typeInterface, Type typeClass, bool bSystem = false, bool bSingleton = false)
        {
            ServiceDescriptor serviceDesc = new ServiceDescriptor(typeInterface,typeClass, bSystem?ServiceScope.System : ServiceScope.Company,
                bSingleton ?ServiceLifeTime.Singleton : ServiceLifeTime.Transient);
            RegisterService(serviceDesc);
        }
        public void RegisterService(ServiceDescriptor serviceDesc)
        {
            if (string.IsNullOrEmpty(serviceDesc?.Name))
            {
                return;
            }
            var key = serviceDesc.Name;
            if (_dict.ContainsKey(key))
            {
                _dict[key] = serviceDesc;
            }
            else
            {
                _dict.Add(serviceDesc.Name, serviceDesc);
            }
        }


        /// <summary>
        /// 自动选择数据库访问相应的服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public Service GetService(string serviceName)
        {
            if (_dict.ContainsKey(serviceName))
            {
                Service service;
                var serviceDesc = _dict[serviceName];
                if (serviceDesc.TypeClass.GetCustomAttribute<ScopeCompanyAttribute>() != null)
                {
                    service = serviceDesc?.GetService();
                }
                else
                {
                    service = serviceDesc?.GetService();
                }
                return service;
            }
            else
            {
                return null;
            }
            
        }


        public Service GetServiceSpec(string serviceName)
        {
            if (_dict.ContainsKey(serviceName))
            {
                var service = _dict[serviceName]?.GetService();
                return service;
            }
            else
            {
                return null;
            }

        }
        public Service GetServiceSpec(string serviceName,Service service)
        {
            if (_dict.ContainsKey(serviceName))
            {
                var theService = _dict[serviceName]?.GetService(service);
                return theService;
            }
            else
            {
                return null;
            }

        }

        public T GetService<T>() where T : Service
        {
            return GetService(typeof(T).Name) as T;
        }

        public T GetServiceSpec<T>(string connString) where T : Service
        {
            return GetServiceSpec(typeof(T).Name) as T;
        }

        public T GetServiceSpec<T>(Service service) where T : Service
        {
            return GetServiceSpec(typeof(T).Name, service) as T;
        }

        public void RegisterService<TInterface, TClass>(bool bSystem = false, bool bSingleton = false) where TClass:Service
        {
            RegisterService(typeof(TInterface), typeof(TClass), bSystem, bSingleton);
        }
        public void RegisterService<TClass>(bool bSystem = false, bool bSingleton = false) where TClass : Service
        {
            RegisterService(null, typeof(TClass), bSystem, bSingleton);
        }

        public IEnumerable<string> GetServiceNames()
        {
            return _dict.Keys;
        }
    }

    

    /// <summary>
    /// 服务描述信息
    /// </summary>
    public class ServiceDescriptor
    {
        private static Service _service;
        public Type TypeInterface { get; set; }
        public Type TypeClass { get; set; }
        public ServiceLifeTime LifeTime { get; set; }
        private static readonly object _obj = new object();
        public ServiceScope Scope { get; set; }
        public Service GetService(string connString)
        {
            if (LifeTime == ServiceLifeTime.Transient)
            {
                return Activator.CreateInstance(TypeClass,new object[] { connString }) as Service;
            }
            else
            {
                if (_service == null)
                {
                    lock (_obj)
                    {
                        if (_service == null)
                        {
                            _service = Activator.CreateInstance(TypeClass, new object[] { connString }) as Service;
                        }
                    }
                }
                return _service;
            }
        }
        public Service GetService(Service service)
        {
            if (LifeTime == ServiceLifeTime.Transient)
            {
                return Activator.CreateInstance(TypeClass, new object[] { service }) as Service;
            }
            else
            {
                if (_service == null)
                {
                    lock (_obj)
                    {
                        if (_service == null)
                        {
                            _service = Activator.CreateInstance(TypeClass, new object[] { service }) as Service;
                        }
                    }
                }
                return _service;
            }
        }
        public Service GetService()
        {
            if (LifeTime == ServiceLifeTime.Transient)
            {
                return Activator.CreateInstance(TypeClass) as Service;
            }
            else
            {
                if (_service == null)
                {
                    lock (_obj)
                    {
                        if (_service == null)
                        {
                            _service = Activator.CreateInstance(TypeClass) as Service;
                        }
                    }
                }
                return _service;
            }
        }
        public string Name => TypeClass.Name;

        public ServiceDescriptor(Type typeInterface, Type typeClass, ServiceScope scope, ServiceLifeTime lifeTime = ServiceLifeTime.Transient) 
        {
            if (typeClass == null)
            {
                throw new ArgumentNullException(nameof(typeClass));
            }
            Scope = scope;
            TypeInterface = typeInterface;
            TypeClass = typeClass;
            LifeTime = lifeTime;
        }
    }

    /// <summary>
    /// 服务创建方式
    /// </summary>
    public enum ServiceLifeTime
    {
        Singleton, //单实例，在整个web生命周期
	    Transient  //每次调用创建
    }

    /// <summary>
    /// 数据服务底层数据来源
    /// </summary>
    public enum ServiceScope
    {
        System, //系统数据库
        Company //公司
    }

    /// <summary>
    /// 系统数据库服务范围
    /// </summary>
    public class ScopeSystemAttribute:Attribute{}
    /// <summary>
    /// 公司数据库服务范围
    /// </summary>
    public class ScopeCompanyAttribute : Attribute { }
}
