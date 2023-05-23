using System.ComponentModel.DataAnnotations.Schema;

namespace WebServerExample.Models
{
    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NoteID { get; set; }
        public string Name { get; set; }
        public string Raw { get; set; }
        public string Tags { get; set; }    
    }
}
