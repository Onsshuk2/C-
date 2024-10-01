using MusicStore_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore_Library
{
    public class RecordService
    {
        public void AddRecord(Record record)
        {
            using (var context = new MusicDB())
            {
                context.Records.Add(record);
               // context.SaveChanges();
            }
        }

        public void DeleteRecord(int recordId)
        {
            using (var context = new MusicDB())
            {
                var record = context.Records.Find(recordId);
                if (record != null)
                {
                    context.Records.Remove(record);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateRecord(Record updatedRecord)
        {
            using (var context = new MusicDB())
            {
                context.Records.Update(updatedRecord);
               // context.SaveChanges();
            }
        }

        public void SellRecord(int recordId)
        {
            using (var context = new MusicDB())
            {
                var record = context.Records.Find(recordId);
                if (record != null)
                {
                    context.SaveChanges();
                }
            }
        }

        public void WriteOffRecord(int recordId)
        {
            using (var context = new MusicDB())
            {
                var record = context.Records.Find(recordId);
                if (record != null)
                {
                    context.Records.Remove(record);
                    context.SaveChanges();
                }
            }
        }
    }
}
