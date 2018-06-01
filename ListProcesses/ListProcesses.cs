using System;
using System.Management;
using System.Collections.Generic;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;

namespace MyService
{
	class MyS 
	{	
		[STAThread]
		static void Main()
		{
			string Namespace = @"root\cimv2";
			string ComputerName = "127.0.0.1";
			string ClassName = "Win32_Process";
			DComSessionOptions DComOptions = new DComSessionOptions();
			DComOptions.Impersonation = ImpersonationType.Impersonate;

			CimSession Session = CimSession.Create(ComputerName, DComOptions);
			IEnumerable<CimInstance> processes = Session.EnumerateInstances(Namespace, ClassName);
			foreach (CimInstance process in processes)
			{
				Console.WriteLine("{0} {1} {2} {3}",
								  process.CimInstanceProperties["Name"],
				                  process.CimInstanceProperties["ParentProcessId"],
			                      process.CimInstanceProperties["ProcessId"],
								  process.CimInstanceProperties["CommandLine"]);
			}
			Console.ReadLine();
		}
	}
}