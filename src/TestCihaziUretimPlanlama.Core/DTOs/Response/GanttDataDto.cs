namespace TestCihaziUretimPlanlama.Core.DTOs.Response
{
    public class GanttDataDto
    {
        public List<GanttTaskDto> Tasks { get; set; } = new List<GanttTaskDto>();
        public List<GanttLinkDto> Links { get; set; } = new List<GanttLinkDto>();
        public List<GanttResourceDto> Resources { get; set; } = new List<GanttResourceDto>();
        public GanttFiltersDto Filters { get; set; } = new GanttFiltersDto();
    }

    public class GanttTaskDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public double Progress { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; } // task, project, milestone
        public string ResourceId { get; set; }
        public string Color { get; set; }
        public string SiparisNo { get; set; }
        public string DepartmanAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string GorevAdi { get; set; }
        public string Durum { get; set; }
        public int Sure { get; set; }
        public string Musteri { get; set; }
        public int Oncelik { get; set; }
    }

    public class GanttLinkDto
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Type { get; set; } = "finish_to_start";
    }

    public class GanttResourceDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }

    public class GanttFiltersDto
    {
        public List<FilterOptionDto> Siparisler { get; set; } = new List<FilterOptionDto>();
        public List<FilterOptionDto> Departmanlar { get; set; } = new List<FilterOptionDto>();
        public List<FilterOptionDto> Personeller { get; set; } = new List<FilterOptionDto>();
        public List<FilterOptionDto> Durumlar { get; set; } = new List<FilterOptionDto>();
    }

    public class FilterOptionDto
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
