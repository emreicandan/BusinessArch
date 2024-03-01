using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;

namespace Core.Aspect.Autofac.Transaction;

public class TransactionScopedAspect:MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using(var transaction = new TransactionScope())
        {
            try
            {
                invocation.Proceed();
                transaction.Complete();
            }
            catch (Exception ex)
            {
                transaction.Dispose();
                throw;
            }
        }
    }
}

