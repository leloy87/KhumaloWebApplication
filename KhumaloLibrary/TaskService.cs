using System.Collections.Generic;
using System.Linq;

namespace KhumaloLibrary
{
    public class TaskService
    {
        private readonly List<TaskItem> _taskItems = new List<TaskItem>();
        private int _nextId = 1;

        public List<TaskItem> GetTaskItems()
        {
            return _taskItems;
        }

        public TaskItem? GetTaskItem(int id)
        {
            return _taskItems.FirstOrDefault(item => item.Id == id);
        }

        public void AddTaskItem(TaskItem item)
        {
            item.Id = _nextId++;
            _taskItems.Add(item);
        }

        public void UpdateTaskItem(TaskItem item)
        {
            var existingItem = GetTaskItem(item.Id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsCompleted = item.IsCompleted;
            }
        }

        public void DeleteTaskItem(int id)
        {
            var item = GetTaskItem(id);
            if (item != null)
            {
                _taskItems.Remove(item);
            }
        }
    }
}
