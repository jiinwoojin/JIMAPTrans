﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Model3DConversion.Models.Common
{
    public static class NFileSystemUtil
    {
        public static string GetAbsolutePath(string parent, string child)
        {
            if (parent == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(child))
            {
                return parent;
            }

            var path_name = Path.Combine(parent, child);

            return Path.GetFullPath(path_name);
        }

        public static string GetDestinationFilePath(string input_root_directory_path, string output_root_directory_path, string intput_file_path)
        {
            var input_file_relative_path = GetRelativePath(input_root_directory_path, intput_file_path);

            return GetAbsolutePath(output_root_directory_path, input_file_relative_path);
        }

        public static string GetRelativePath(string from_directory, string to_path)
        {
            if (from_directory == null)
            {
                throw new ArgumentNullException("from_directory");
            }

            if (to_path == null)
            {
                to_path = string.Empty;
            }

            var is_rooted = Path.IsPathRooted(from_directory) && Path.IsPathRooted(to_path);

            if (is_rooted)
            {
                var is_different_root = string.Compare(Path.GetPathRoot(from_directory), Path.GetPathRoot(to_path), StringComparison.OrdinalIgnoreCase) != 0;

                if (is_different_root)
                {
                    return to_path;
                }
            }

            var relative_path = new List<string>();
            var from_directories = from_directory.Split(Path.DirectorySeparatorChar);
            var to_directories = to_path.Split(Path.DirectorySeparatorChar);
            var length = Math.Min(from_directories.Length, to_directories.Length);
            var last_common_root = -1;
            for (var x = 0; x < length; x++)
            {
                if (string.Compare(from_directories[x], to_directories[x], StringComparison.OrdinalIgnoreCase) != 0)
                {
                    break;
                }

                last_common_root = x;
            }

            if (last_common_root == -1)
            {
                return to_path;
            }

            for (var x = last_common_root + 1; x < from_directories.Length; x++)
            {
                if (from_directories[x].Length > 0)
                {
                    relative_path.Add("..");
                }
            }

            for (var x = last_common_root + 1; x < to_directories.Length; x++)
            {
                relative_path.Add(to_directories[x]);
            }

            var relative_parts = new string[relative_path.Count];
            relative_path.CopyTo(relative_parts, 0);
            var new_path = string.Join(Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture), relative_parts);

            return new_path;
        }
    }
}