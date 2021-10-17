﻿using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Tools;

namespace Isu.Entities
{
    public class Group
    {
        private const int MinCourse = 1;
        private const int MaxCourse = 4;
        private const int MinGroup = 0;
        private const int MaxGroup = 99;
        private string _groupName;
        public Group(string groupName, int maximumNumberOfStudents, string prefix = "M3")
        {
            Prefix = prefix;
            GroupName = groupName;
            Students = new List<Student>();
            MaximumNumberOfStudents = maximumNumberOfStudents;
        }

        public string GroupName
        {
            get => _groupName;
            private set
            {
                if (!(value.StartsWith(Prefix) && value[2] - '0' <= MaxCourse && value[2] - '0' >= MinCourse &&
                    (value[3] + value[4] - '0' is >= MinGroup and <= MaxGroup) && value.Length == 5))
                    throw new IsuException("Invalid group number");
                _groupName = value;
            }
        }

        public List<Student> Students { get; }
        public int MaximumNumberOfStudents { get; }
        public string Prefix { get; }

        public Student AddStudent(Student student)
        {
            if (MaximumNumberOfStudents == Students.Count)
                throw new IsuException("Group is full, student cannot be added");
            Students.Add(student);
            return Students.Last();
        }

        public void TransferStudent(Student student, Group oldGroup)
        {
            oldGroup.Students.Remove(student);
            AddStudent(new Student(student.Id, student.Name, GroupName));
        }

        public Student GetStudent(Guid id)
        {
            return Students.FirstOrDefault(student => student.Id == id);
        }

        public Student GetStudent(string name)
        {
            return Students.FirstOrDefault(student => student.Name == name);
        }
    }
}