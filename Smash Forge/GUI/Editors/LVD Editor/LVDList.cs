﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Smash_Forge
{
    public partial class LVDList : DockContent
    {
        public LVD TargetLVD;
        public LVDEditor lvdEditor;

        public LVDList()
        {
            InitializeComponent();
            treeView1.Nodes.Add(collisionNode);
            treeView1.Nodes.Add(spawnNode);
            treeView1.Nodes.Add(respawnNode);
            treeView1.Nodes.Add(camNode);
            treeView1.Nodes.Add(deathNode);
            treeView1.Nodes.Add(itemNode);
            treeView1.Nodes.Add(shapeNode);
            treeView1.Nodes.Add(pointNode);
            treeView1.Nodes.Add(hurtNode);
            treeView1.Nodes.Add(enemyNode);

            collisionNode.ContextMenu = new ContextMenu();
            MenuItem AddCollision = new MenuItem("Add New Collision");
            AddCollision.Click += delegate
            {
                TargetLVD.collisions.Add(new Collision() { name = "COL_00_NewCollision", subname = "00_NewCollision" });
                fillList();
            };
            collisionNode.ContextMenu.MenuItems.Add(AddCollision);

            //---------------------------------------------
            {
                spawnNode.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New Spawn");
                Add.Click += delegate
                {
                    TargetLVD.spawns.Add(new Spawn() { name = "START_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                spawnNode.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = respawnNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New Respawn");
                Add.Click += delegate
                {
                    TargetLVD.respawns.Add(new Spawn() { name = "RESTART_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = camNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New Camera Bounds");
                Add.Click += delegate
                {
                    TargetLVD.cameraBounds.Add(new Bounds() { name = "CAMERA_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = deathNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New Blastzones");
                Add.Click += delegate
                {
                    TargetLVD.blastzones.Add(new Bounds() { name = "DEATH_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = itemNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New Item Spawner");
                Add.Click += delegate
                {
                    TargetLVD.itemSpawns.Add(new ItemSpawner() { name = "ITEM_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = pointNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New General Point");
                Add.Click += delegate
                {
                    TargetLVD.generalPoints.Add(new GeneralPoint() { name = "POINT_00_NEW", subname = "00_NEW" });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = shapeNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New General Shape (Point)");
                Add.Click += delegate
                {
                    TargetLVD.generalShapes.Add(new GeneralShape() { name = "POINT_00_NEW", subname = "00_NEW", type = 1 });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = shapeNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New General Shape (Rectangle)");
                Add.Click += delegate
                {
                    TargetLVD.generalShapes.Add(new GeneralShape() { name = "RECT_00_NEW", subname = "00_NEW", type = 3 });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }
            //---------------------------------------------
            {
                TreeNode node = shapeNode;
                node.ContextMenu = new ContextMenu();
                MenuItem Add = new MenuItem("Add New General Shape (Path)");
                Add.Click += delegate
                {
                    TargetLVD.generalShapes.Add(new GeneralShape() { name = "PATH_00_NEW", subname = "00_NEW", type = 4 });
                    fillList();
                };
                node.ContextMenu.MenuItems.Add(Add);
            }

        }

        public TreeNode collisionNode = new TreeNode("Collisions");
        public TreeNode spawnNode = new TreeNode("Spawns");
        public TreeNode respawnNode = new TreeNode("Respawns");
        public TreeNode camNode = new TreeNode("Camera Bounds");
        public TreeNode deathNode = new TreeNode("Death Bounds");
        public TreeNode itemNode = new TreeNode("Item Spawners");
        public TreeNode shapeNode = new TreeNode("General Shapes");
        public TreeNode pointNode = new TreeNode("General Points");
        public TreeNode hurtNode = new TreeNode("Hurtboxes");
        public TreeNode enemyNode = new TreeNode("Enemy Spawners");

        public void fillList()
        {
            collisionNode.Nodes.Clear();
            spawnNode.Nodes.Clear();
            respawnNode.Nodes.Clear();
            camNode.Nodes.Clear();
            deathNode.Nodes.Clear();
            itemNode.Nodes.Clear();
            pointNode.Nodes.Clear();
            hurtNode.Nodes.Clear();
            enemyNode.Nodes.Clear();
            shapeNode.Nodes.Clear();

            if(TargetLVD != null)
            {
                foreach (Collision c in TargetLVD.collisions)
                {
                    collisionNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (Spawn c in TargetLVD.spawns)
                {
                    spawnNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (Spawn c in TargetLVD.respawns)
                {
                    respawnNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (Bounds c in TargetLVD.cameraBounds)
                {
                    camNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (Bounds c in TargetLVD.blastzones)
                {
                    deathNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (ItemSpawner c in TargetLVD.itemSpawns)
                {
                    itemNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (GeneralPoint c in TargetLVD.generalPoints)
                {
                    pointNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }

                foreach (GeneralShape s in TargetLVD.generalShapes)
                {
                    shapeNode.Nodes.Add(new TreeNode(s.name) { Tag = s });
                }

                foreach (DamageShape s in TargetLVD.damageShapes)
                {
                    hurtNode.Nodes.Add(new TreeNode(s.name) { Tag = s });
                }

                foreach (EnemyGenerator c in TargetLVD.enemySpawns)
                {
                    enemyNode.Nodes.Add(new TreeNode(c.name) { Tag = c });
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level != 0)
            {
                TargetLVD.LVDSelection = e.Node.Tag;
                //MainForm.Instance.viewports[0].timeSinceSelected.Restart();
                lvdEditor.open((LVDEntry)e.Node.Tag, e.Node);
            }
        }

        public void deleteSelected()
        {
            if(treeView1.SelectedNode.Tag is LVDEntry)
            {
                LVDEntry entry = (LVDEntry)treeView1.SelectedNode.Tag;
                if (entry is Bounds)
                {
                    TargetLVD.blastzones.Remove((Bounds)entry);
                    TargetLVD.cameraBounds.Remove((Bounds)entry);
                }
                if (entry is Spawn)
                {
                    TargetLVD.respawns.Remove((Spawn)entry);
                    TargetLVD.spawns.Remove((Spawn)entry);
                }
                if (entry is Collision)
                    TargetLVD.collisions.Remove((Collision)entry);
                if (entry is DamageShape)
                    TargetLVD.damageShapes.Remove((DamageShape)entry);
                if (entry is EnemyGenerator)
                    TargetLVD.enemySpawns.Remove((EnemyGenerator)entry);
                if (entry is GeneralShape)
                    TargetLVD.generalShapes.Remove((GeneralShape)entry);
                if (entry is ItemSpawner)
                    TargetLVD.itemSpawns.Remove((ItemSpawner)entry);
                if (entry is GeneralPoint)
                    TargetLVD.generalPoints.Remove((GeneralPoint)entry);

                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                DialogResult r =
                        MessageBox.Show(
                            "Are you sure?\nThis cannot be undone",
                            "Delete Selected Entry", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    deleteSelected();
                }
            }
        }
    }
}
