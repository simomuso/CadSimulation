﻿namespace CadSimulation.Core.Models
{
    public class PersistenceServiceOptions
    {
        public string FilesystemPath { get; set; } = null!;
        public Uri? ServiceUri { get; set; } = null!;
        public bool UseJsonFormat { get; set; }
    }
}
