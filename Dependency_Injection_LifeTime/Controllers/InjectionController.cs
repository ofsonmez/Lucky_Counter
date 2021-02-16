using System;
using Dependency_Injection_LifeTime.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection_LifeTime.Controllers
{
    [ApiController]
    public class InjectionController : ControllerBase
    {
        private readonly ScopedService _scopedCounter1;
        private readonly ScopedService _scopedCounter2;
        
        private readonly SingletonService _singletonCounter1;
        private readonly SingletonService _singletonCounter2;
        
        private readonly TransientService _transientCounter1;
        private readonly TransientService _transientCounter2;

        public InjectionController(ScopedService scopedCounter1, ScopedService scopedCounter2,
            SingletonService singletonCounter1,
            SingletonService singletonCounter2,
            TransientService transientCounter1,
            TransientService transientCounter2)
        {
            _scopedCounter1 = scopedCounter1;
            _scopedCounter2 = scopedCounter2;
            
            _singletonCounter1 = singletonCounter1;
            _singletonCounter2 = singletonCounter2;
            
            _transientCounter1 = transientCounter1;
            _transientCounter2 = transientCounter2;
        }
        
        [HttpGet]
        [Route("")]
        public string Get()
        {
            string result = $"{Environment.NewLine}Singleton Counter1: {_singletonCounter1.GetNextCounter()} - Every subsequent request uses the same instance.{Environment.NewLine}" +
                            $"Singleton Counter2: {_singletonCounter2.GetNextCounter()} - Every subsequent request uses the same instance.{Environment.NewLine}" +
                            $"{Environment.NewLine}Scoped Counter1: {_scopedCounter1.GetNextCounter()} - Every subsequent request uses one instance in that scope. {Environment.NewLine}" +
                            $"Scoped Counter2: {_scopedCounter2.GetNextCounter()} - So every new request which I send increments counter one by one. {Environment.NewLine}" +
                            $"{Environment.NewLine}Transient Counter1: {_transientCounter1.GetNextCounter()} - Every subsequent request creates new instance. {Environment.NewLine}" +
                            $"Transient Counter2: {_transientCounter2.GetNextCounter()} - So every new request which I send, once increments _transientCounter1 and then increments _transientCounter2. {Environment.NewLine}";

            return result;
        }
    }
}