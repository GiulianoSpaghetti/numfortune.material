﻿

using System;
using WixSharp;

namespace numfortune_setup
{
    internal class Program
    {
        static void Main()
        {
            Project project = new Project("numfortune.Avalonia",
                              new Dir(@"[ProgramFiles64Folder]\\numfortune.Avalonia",
                                  new DirFiles(@"*.*"),
                                  new Dir("runtimes",
                                      new Dir("win-x64",
                                            new Dir("native",
                                                new File("runtimes\\win-x64\\native\\libHarfBuzzSharp.dll"),
                                                new File("runtimes\\win-x64\\native\\libSkiaSharp.dll")
                                            )
                                        )
                                    )
                        ),
                        new Dir(@"%ProgramMenu%",
                         new ExeFileShortcut("numerone's fortune", "[ProgramFiles64Folder]\\numfortune.Avalonia\\numfortune.Desktop.exe", "") { WorkingDirectory = "[INSTALLDIR]" }
                      )
            );

            project.GUID = new Guid("90D24925-7418-48AD-9950-676C2F839B20");
            project.Version = new Version("3.0.0.6");
            project.Platform = Platform.x64;
            project.SourceBaseDir = "f:\\source\\Numfortune.material\\numfortune.Desktop\\bin\\Release\\net9.0-windows10.0.26100.0";
            project.LicenceFile = "LICENSE.rtf";
            project.OutDir = "f:\\";
            project.ControlPanelInfo.Manufacturer = "Giulio Sorrentino";
            project.ControlPanelInfo.Name = "numerone's fortune in avalonia";
            project.ControlPanelInfo.HelpLink = "https://github.com/GiulianoSpaghetti/numfortune.material/issues";
            project.Description = "Un fortune teller per windows 10 e 11 con cookie americani nel dialetto material di google di avalonia";
            project.BuildMsi();
        }
    }
}
