using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Input;
﻿using Avalonia.Platform.Storage;
using Avalonia.Threading;
using Material.Styles.Controls;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Threading;
using ReactiveUI;

namespace numfortune.ViewModels;

public class MainViewModel : ViewModelBase
{
    private HttpResponseMessage httpResponse;
    private HttpClient client = new HttpClient();
    private string s;
    private string _cookie;
    public string Cookie { get => _cookie; set => this.RaiseAndSetIfChanged(ref _cookie, value) ;}
    public ICommand Click { get; private set; }
    private String _status = string.Empty;
        public string Status
    {
        get => _status; set
        {
            this.RaiseAndSetIfChanged(ref _status, value);
            try 
            {
             	SnackbarHost.Post(_status, null, DispatcherPriority.Normal);
            }
            catch (System.InvalidOperationException ex1)
            {
            	Cookie=_status;
            }
        }
    }
    public MainViewModel()
    {
        Click = ReactiveCommand.Create(Tick);
        Tick();
    }
    private void Tick()
    {
        s = "";
        try
        {
            httpResponse = client.GetAsync("https://helloacm.com/api/fortune/").Result;

            if (httpResponse.IsSuccessStatusCode)
            {

                s = httpResponse.Content.ReadAsStringAsync().Result;
                s = s.Substring(1, s.Length - 2);
                s = s.Replace("\\n", System.Environment.NewLine);
                s = s.Replace("\\t", "	");
                s = s.Replace("\\b", "");
                s = s.Replace("\\\"", "\"");
            }
            else
            {
                Cookie = $"The HTTP status code is ${httpResponse.StatusCode}";
                return;
            }
        }
        catch (HttpRequestException ex)
        {
            Status = ex.Message;
            return;
        	
        }
        catch (SocketException ex)
        {
            Status = ex.Message;
            return;
        }
        catch (AggregateException ex)
        {
	    Status = ex.Message;
            return;
        }
        Cookie =s;
    }
}
