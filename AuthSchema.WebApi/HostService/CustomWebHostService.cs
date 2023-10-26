using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AuthSchema.WebApi.HostService
{
    public class CustomWebHostService : WebHostService
    {
        private readonly ILogger _logger;

        public CustomWebHostService(IWebHost host) : base(host)
        {
            _logger = host.Services.GetRequiredService<ILogger<CustomWebHostService>>();
        }

        protected override void OnStarting(string[] args)
        {
            try
            {
                _logger.LogInformation("OnStaring :: Início");
                base.OnStarting(args);
                _logger.LogInformation("OnStaring :: Fim");

            }catch(Exception ex)
            {
                _logger.LogCritical($"OnStarting:: Erro durante a inicialização. Mensagem: {ex.Message}. StackTrace: {ex.StackTrace}.");
                throw ex;
            }
        }

        protected override void OnStarted()
        {
            try
            {
                _logger.LogInformation("OnStarted :: Início");
                base.OnStarted();
                _logger.LogInformation("OnStarted :: Fim");

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"OnStarted:: Erro após a inicialização. Mensagem: {ex.Message}. StackTrace: {ex.StackTrace}.");
                throw ex;
            }
        }

        protected override void OnPause()
        {
            try
            {
                _logger.LogInformation("OnPause :: Início");
                base.OnPause();
                _logger.LogInformation("OnPause :: Fim");

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"OnPause:: Erro ao pausar a aplicação. Mensagem: {ex.Message}. StackTrace: {ex.StackTrace}.");
                throw ex;
            }
        }

        protected override void OnContinue()
        {
            try
            {
                _logger.LogInformation("OnContinue :: Início");
                base.OnPause();
                _logger.LogInformation("OnContinue :: Fim");

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"OnPause:: Erro ao retomar a aplicação. Mensagem: {ex.Message}. StackTrace: {ex.StackTrace}.");
                throw ex;
            }
        }

        protected override void OnStopping()
        {
            try
            {
                _logger.LogInformation("OnStopping :: Início");
                base.OnStopping();
                _logger.LogInformation("OnStopping :: Fim");

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"OnStopping:: Erro durante a finalização do serviço. Mensagem: {ex.Message}. StackTrace: {ex.StackTrace}.");
                throw ex;
            }
        }
    }
}
