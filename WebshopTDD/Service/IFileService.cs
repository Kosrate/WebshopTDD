﻿namespace WebshopTDD.Service
{
    public interface IFileService
    {
        bool Exists(string path);
        string ReadAllText(string path);
        void WriteAllText(string path, string content);
    }
}