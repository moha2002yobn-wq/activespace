using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ActiveSpaceSystem.Tests
{
    public class DataAccessLayerTests
    {
        private readonly TestDataContext _context = new TestDataContext();

        [Fact]
        public void CreateRecord_Should_AddToDatabase()
        {
            var record = new TestRecord { Id = 1, Name = "Test", CreatedAt = DateTime.Now };
            var result = _context.AddRecord(record);
            result.Should().BeTrue();
            _context.Records.Should().Contain(record);
        }

        [Fact]
        public void ReadRecord_Should_ReturnCorrectData()
        {
            var record = new TestRecord { Id = 1, Name = "Test", CreatedAt = DateTime.Now };
            _context.AddRecord(record);
            var result = _context.GetRecordById(1);
            result.Should().NotBeNull();
            result.Name.Should().Be("Test");
        }

        [Fact]
        public void UpdateRecord_Should_ModifyExistingData()
        {
            var record = new TestRecord { Id = 1, Name = "Original", CreatedAt = DateTime.Now };
            _context.AddRecord(record);
            record.Name = "Updated";
            var result = _context.UpdateRecord(record);
            result.Should().BeTrue();
            _context.GetRecordById(1).Name.Should().Be("Updated");
        }

        [Fact]
        public void DeleteRecord_Should_RemoveFromDatabase()
        {
            var record = new TestRecord { Id = 1, Name = "Test", CreatedAt = DateTime.Now };
            _context.AddRecord(record);
            var result = _context.DeleteRecord(1);
            result.Should().BeTrue();
            _context.Records.Should().NotContain(record);
        }

        [Fact]
        public void BulkInsert_Should_HandleMultipleRecords()
        {
            var records = new List<TestRecord>
            {
                new TestRecord { Id = 1, Name = "Record1", CreatedAt = DateTime.Now },
                new TestRecord { Id = 2, Name = "Record2", CreatedAt = DateTime.Now },
                new TestRecord { Id = 3, Name = "Record3", CreatedAt = DateTime.Now }
            };
            var result = _context.BulkInsert(records);
            result.Should().BeTrue();
            _context.Records.Should().HaveCount(3);
        }
    }

    public class PerformanceTests
    {
        [Fact]
        public void SimpleOperation_Should_CompleteWithinTimeLimit()
        {
            var stopwatch = Stopwatch.StartNew();
            PerformSimpleOperation();
            stopwatch.Stop();
            stopwatch.ElapsedMilliseconds.Should().BeLessThan(100);
        }

        [Fact]
        public void ComplexOperation_Should_CompleteWithinTimeLimit()
        {
            var stopwatch = Stopwatch.StartNew();
            PerformComplexOperation();
            stopwatch.Stop();
            stopwatch.ElapsedMilliseconds.Should().BeLessThan(1000);
        }

        [Fact]
        public void ParallelOperations_Should_ExecuteEfficiently()
        {
            var tasks = new List<System.Threading.Tasks.Task>();
            for (int i = 0; i < 10; i++)
                tasks.Add(System.Threading.Tasks.Task.Run(() => PerformSimpleOperation()));
            System.Threading.Tasks.Task.WaitAll(tasks.ToArray());
            tasks.Should().AllSatisfy(t => t.IsCompleted.Should().BeTrue());
        }

        private void PerformSimpleOperation() => var result = 2 + 2;
        private void PerformComplexOperation() => var data = Enumerable.Range(1, 1000).Select(x => x * x).Where(x => x % 2 == 0).ToList();
    }

    public class SecurityTests
    {
        [Theory]
        [InlineData("'; DROP TABLE Users; --")]
        [InlineData("<script>alert('XSS')</script>")]
        [InlineData("../../../etc/passwd")]
        public void MaliciousInput_Should_BeRejected(string maliciousInput)
        {
            var validator = new SecurityValidator();
            var result = validator.IsSafe(maliciousInput);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("normal_input")]
        [InlineData("user@example.com")]
        [InlineData("123-456-7890")]
        public void LegitimateInput_Should_BeAccepted(string legitimateInput)
        {
            var validator = new SecurityValidator();
            var result = validator.IsSafe(legitimateInput);
            result.Should().BeTrue();
        }
    }

    public class TestRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TestDataContext
    {
        public List<TestRecord> Records { get; } = new List<TestRecord>();
        public bool AddRecord(TestRecord record) { Records.Add(record); return true; }
        public TestRecord GetRecordById(int id) => Records.FirstOrDefault(r => r.Id == id);
        public bool UpdateRecord(TestRecord record)
        {
            var existing = GetRecordById(record.Id);
            if (existing == null) return false;
            existing.Name = record.Name;
            return true;
        }
        public bool DeleteRecord(int id)
        {
            var record = GetRecordById(id);
            if (record == null) return false;
            Records.Remove(record);
            return true;
        }
        public bool BulkInsert(List<TestRecord> records) { Records.AddRange(records); return true; }
    }

    public class SecurityValidator
    {
        public bool IsSafe(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            var dangerousPatterns = new[] { "'", "<", ">", "--", ";" };
            return !dangerousPatterns.Any(pattern => input.Contains(pattern));
        }
    }
}
