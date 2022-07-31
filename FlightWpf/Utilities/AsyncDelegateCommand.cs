using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightWpf.Utilities
{
    public class AsyncDelegateCommand : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            ExecuteAsync(parameter).SafeFireAndForget();
        }
        public Task ExecuteAsync(object param)
        {
            return Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                }
            });
        }
    }
    static class AsyncUtilities
    {
        public static async void SafeFireAndForget(this Task t)
        {
            try
            {
                await t;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
