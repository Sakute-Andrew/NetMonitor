// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using NetMonitor.cli;
using NetMonitor.entities;
using NetMonitor.repo;
using NetMonitor.service;
using SharpPcap;

namespace NetMonitor;

static class MainClass{
    
    public static void Main(string[] args)
    {
        CliService service = new CliServiceImpl();
        service.initMenu();
    }
    
}