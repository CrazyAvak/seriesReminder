using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace killerapp
{
    public class serie
    {
        private int id;
        private string name;
        private int season;
        private int episode;
        private DateTime created;
        private DateTime updated;
        private string type;
        private string rating;
        private string status;

        public string Name { get => name; set => name = value; }
        public int Season { get => season; set => season = value; }
        public int Episode { get => episode; set => episode = value; }
        public DateTime Created { get => created; set => created = value; }
        public DateTime Updated { get => updated; set => updated = value; }
        public string Type { get => type; set => type = value; }
        public string Rating { get => rating; set => rating = value; }
        public string Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }
    }
}
