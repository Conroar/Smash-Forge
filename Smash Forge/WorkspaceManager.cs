﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using SALT.Scripting;
using SALT.Scripting.AnimCMD;
using SALT.Scripting.MSC;
using System.Xml;
using SALT.PARAMS;

namespace Smash_Forge
{
    class WorkspaceManager
    {
        public WorkspaceManager() { Projects = new SortedList<string, FitProj>(); }
        public SortedList<string, FitProj> Projects { get; set; }
        public string WorkspaceRoot { get; set; }
    }

    public class FitProj
    {
        public FitProj()
        {
            ACMD_FILES = new List<string>();
            MSC_FILES = new List<string>();
            ANIM_FILES = new List<string>();
            MODEL_FILES = new List<string>();
            TEXTURE_FILES = new List<string>();
            PARAM_FILES = new List<string>();
            ANIM_FILES = new List<string>();
        }
        public FitProj(string filepath) : this()
        {
            ProjFile = ReadProject(filepath);
        }

        // Project Properties
        public XmlDocument ProjFile { get; set; }
        public string ProjPath { get; set; }
        public string ProjRoot { get { return Path.GetDirectoryName(ProjPath); } }
        public string ProjName { get; set; }
        public string ToolVer { get; set; }
        public string GameVer { get; set; }
        public string Platform { get; set; }

        public List<string> ACMD_FILES { get; set; }
        public List<string> MSC_FILES { get; set; }
        public List<string> ANIM_FILES { get; set; }
        public List<string> MODEL_FILES { get; set; }
        public List<string> TEXTURE_FILES { get; set; }
        public List<string> PARAM_FILES { get; set; }
        public string MLIST { get; set; }

        private XmlDocument ReadProject(string filepath)
        {
            ProjPath = filepath;
            var proj = new XmlDocument();
            proj.Load(filepath);

            var node = proj.SelectSingleNode("//Project");
            this.ToolVer = node.Attributes["ToolVer"].Value;
            this.GameVer = node.Attributes["GameVer"].Value;
            this.Platform = node.Attributes["Platform"].Value;

            node = proj.SelectSingleNode("//Project/ACMD");
            foreach (XmlNode child in node.ChildNodes)
                ACMD_FILES.Add(Path.Combine(Path.GetDirectoryName(filepath), $"/{child.Attributes["include"].Value}"));

            node = proj.SelectSingleNode("//Project/MSC");
            foreach (XmlNode child in node.ChildNodes)
                MSC_FILES.Add(Path.Combine(Path.GetDirectoryName(filepath), $"/{child.Attributes["include"].Value}"));

            node = proj.SelectSingleNode("//Project/PARAMS");
            foreach (XmlNode child in node.ChildNodes)
                PARAM_FILES.Add(Path.Combine(Path.GetDirectoryName(filepath), $"/{node.Attributes["include"].Value}"));
            
            node = proj.SelectSingleNode("//Project/ANIM");
            foreach (XmlNode child in node.ChildNodes)
                ANIM_FILES.Add(child.Attributes["include"].Value);

            node = proj.SelectSingleNode("//Project/MODEL");
            foreach (XmlNode child in node.ChildNodes)
                MODEL_FILES.Add(child.Attributes["include"].Value);

            node = proj.SelectSingleNode("//Project/TEX");
            foreach (XmlNode child in node.ChildNodes)
                TEXTURE_FILES.Add(child.Attributes["include"].Value);

            return proj;
        }
        public XmlDocument WriteFitproj(string filepath)
        {
            var writer = XmlWriter.Create(filepath, new XmlWriterSettings() { Indent = true, IndentChars = "\t" });
            writer.WriteStartDocument();
            writer.WriteStartElement("Project");
            writer.WriteAttributeString("Name", ProjName);
            writer.WriteAttributeString("ToolVer", ToolVer);
            writer.WriteAttributeString("GameVer", GameVer);
            writer.WriteAttributeString("Platform", Platform);

            writer.WriteStartElement("MLIST");
            if (!string.IsNullOrEmpty(MLIST))
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", MLIST);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("PARAMS");
            foreach (var param in PARAM_FILES)
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", param);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("ACMD");
            foreach (var acmd in ACMD_FILES)
            {
                    writer.WriteStartElement("Import");
                    writer.WriteAttributeString("include", acmd);
                    writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("MSC");
            foreach (var msc in MSC_FILES)
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", msc);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("ANIM");
            foreach (var anim in ANIM_FILES)
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", anim);

                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("MODEL");
            foreach (var mdl in MODEL_FILES)
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", mdl);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("TEX");
            foreach (var tex in TEXTURE_FILES)
            {
                writer.WriteStartElement("Import");
                writer.WriteAttributeString("include", tex);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            var doc = new XmlDocument();
            doc.Load(filepath);
            return doc;
        }
    }
    public enum ProjType
    {
        Fighter,
        Weapon
    }
}
