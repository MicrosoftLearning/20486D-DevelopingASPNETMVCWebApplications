using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignProject
{
    public class Photo
    {
        public int PhotoID
        {
            get => default(int);
            set
            {
            }
        }

        public string Title
        {
            get => default(string);
            set
            {
            }
        }

        public byte[] PhotoFile
        {
            get => default(byte[]);
            set
            {
            }
        }

        public string Description
        {
            get => default(string);
            set
            {
            }
        }

        public System.DateTime CreatedDate
        {
            get => default(System.DateTime);
            set
            {
            }
        }

        public string Owner
        {
            get => default(string);
            set
            {
            }
        }

        public List<Comment> PhotoComments
        {
            get => default(List<Comment>);
            set
            {
            }
        }
    }
}