﻿using System;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace ClassRoom.Presenters
{
    public class ApplicationController
    {
        private readonly MainWindow _shell;

        public ApplicationController(MainWindow shell)
        {
            _shell = shell;
        }

        public void ShowMenu()
        {
            new MenuPresenter(this);
        }

        public void DisplayInShell(object view)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            _shell.TransitionTo(view);
        }

        public string RequestDirectoryFromUser()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Please choose a folder.";
            dialog.CheckFileExists = false;
            dialog.FileName = "[Get Folder]";
            dialog.Filter = "Folders|no.files";

            if ((bool)dialog.ShowDialog())
            {
                string path = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }
    }
}