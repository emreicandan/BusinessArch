using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptor;

public abstract class MethodInterception:MethodInterceptionBaseAttribute
{
    protected virtual void OnBefore(IInvocation invocation) { }

    protected virtual void OnAfter(IInvocation invocation) { }

    protected virtual void OnException(IInvocation invocation,Exception ex) { }

    protected virtual void OnSuccess(IInvocation invocation) { }

    public override void Intercept(IInvocation invocation)
    {
        bool isSuccess = true;
        OnBefore(invocation); // öncesinde çalışması gereken bir durum varsa o çalışır.
        try
        {
            //IInvocation, çalışan metodun tüm bilgilerini içerir ve hatta metodun argümanlarını değiştirebilir veya
            //sonucunu değiştirebilir.
            invocation.Proceed();
            // Bu, asıl metodu çalıştırmak için kullanılır.
        }
        catch (Exception ex)
        {
            isSuccess = false;

            OnException(invocation, ex);
            //Hata alırsan onExceptionu gönder.
            throw;
        }
        finally
        {
            if (isSuccess)//Burasıda işlem başarılıysa dön dedik.
                OnSuccess(invocation);
        }
        OnAfter(invocation);//sonrasında yapılacak işlem varsa.
    }
}

