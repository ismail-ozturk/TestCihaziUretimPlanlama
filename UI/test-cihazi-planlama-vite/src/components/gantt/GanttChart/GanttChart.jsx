// src/components/gantt/GanttChart/GanttChart.jsx
import React, { useEffect, useRef } from 'react';
import { gantt } from 'dhtmlx-gantt';
import 'dhtmlx-gantt/codebase/dhtmlxgantt.css';

const GanttChart = ({ tasks, links, onTaskUpdate, onLinkUpdate, height = '100%' }) => {
  const ganttContainer = useRef(null);

  // Görevlerden tarih aralığını hesapla
  const calculateDateRange = (tasks) => {
    if (!tasks || tasks.length === 0) {
      return {
        start: new Date(),
        end: new Date(Date.now() + 30 * 24 * 60 * 60 * 1000)
      };
    }

    let minDate = null;
    let maxDate = null;

    tasks.forEach(task => {
      if (task.start_date) {
        const startDate = new Date(task.start_date);
        if (!minDate || startDate < minDate) {
          minDate = startDate;
        }
      }

      if (task.start_date && task.duration) {
        const startDate = new Date(task.start_date);
        const endDate = new Date(startDate.getTime() + (task.duration * 60 * 60 * 1000));
        
        if (!maxDate || endDate > maxDate) {
          maxDate = endDate;
        }
      }
    });

    if (!minDate) minDate = new Date();
    if (!maxDate) maxDate = new Date(Date.now() + 30 * 24 * 60 * 60 * 1000);

    const bufferDays = 3;
    minDate = new Date(minDate.getTime() - (bufferDays * 24 * 60 * 60 * 1000));
    maxDate = new Date(maxDate.getTime() + (bufferDays * 24 * 60 * 60 * 1000));

    return { start: minDate, end: maxDate };
  };

  useEffect(() => {
    // Saat bazlı çalışma için konfigürasyon
    gantt.config.duration_unit = "hour";
    gantt.config.work_time = true;
    gantt.config.correct_work_time = true;
    
    gantt.setWorkTime({ 
      hours: [7, 23]
    });

    // Scale konfigürasyonu
    gantt.config.scales = [
      { 
        unit: "day", 
        step: 1, 
        format: "%d %M %Y",
        css: function(date) {
          if (date.getDay() === 0 || date.getDay() === 6) {
            return "weekend-day";
          }
          if (gantt.date.date_part(new Date()).valueOf() === gantt.date.date_part(date).valueOf()) {
            return "today";
          }
          return "workday";
        }
      },
      { 
        unit: "hour", 
        step: 12,
        format: "%H:%i",
        css: function(date) {
          const hour = date.getHours();
          if (hour === 7) return "morning-shift";
          if (hour === 15) return "afternoon-shift";
          if (hour === 19) return "evening-shift";
          return "hour-scale";
        }
      }
    ];

    gantt.config.date_format = "%Y-%m-%d %H:%i:%s";
    
    // Grid kolonları
    gantt.config.columns = [
      { name: "text", label: "Görev", width: 300, tree: true },
      { name: "start_date", label: "Başlangıç", width: 140 },
      { 
        name: "duration", 
        label: "Süre (Saat)", 
        width: 80, 
        align: "center",
        template: function(task) {
          return task.duration + "h";
        }
      },
      { name: "progress", label: "İlerleme", width: 80, align: "center" },
      { name: "departmanAdi", label: "Departman", width: 100, align: "center" },
      { name: "personelAdi", label: "Personel", width: 150 }
    ];

    // Tam boyut konfigürasyonu
    gantt.config.grid_width = 850;
    gantt.config.autosize = false;
    gantt.config.autofit = false;
    gantt.config.scroll_on_load = true;
    gantt.config.preserve_scroll = true;

    // Layout konfigürasyonu
    gantt.config.layout = {
      css: "gantt_container",
      rows: [
        {
          cols: [
            { view: "grid", scrollX: "gridScroll", scrollY: "scrollVer" },
            { resizer: true, width: 1 },
            { view: "timeline", scrollX: "scrollHor", scrollY: "scrollVer" },
            { view: "scrollbar", id: "scrollVer" }
          ]
        },
        { view: "scrollbar", id: "scrollHor", height: 20 }
      ]
    };

    // Departman bazlı renk kodlaması
    gantt.templates.task_class = function(start, end, task) {
      if (task.type === 'project') return 'project-task';
      if (task.departmanAdi === 'PMD') return 'pmd-task';
      if (task.departmanAdi === 'CNC') return 'cnc-task';
      if (task.departmanAdi === 'Teknik') return 'teknik-task';
      return '';
    };

    gantt.templates.task_text = function(start, end, task) {
      if (task.type === 'project') {
        return `<b>${task.text}</b>`;
      }
      return `${task.text} (${task.duration}h)`;
    };

    gantt.templates.tooltip_text = function(start, end, task) {
      if (task.type === 'project') {
        const totalHours = task.duration || 0;
        const days = Math.floor(totalHours / 8);
        const remainingHours = totalHours % 8;
        
        return `
          <div style="padding: 12px; max-width: 300px;">
            <div style="font-weight: bold; font-size: 14px; margin-bottom: 8px;">${task.text}</div>
            <div><b>Sipariş:</b> ${task.siparisNo}</div>
            <div><b>Müşteri:</b> ${task.musteri}</div>
            <div><b>Öncelik:</b> ${task.oncelik}</div>
            <div><b>Toplam Süre:</b> ${totalHours}h (${days} gün ${remainingHours}h)</div>
            <div><b>Başlangıç:</b> ${gantt.templates.tooltip_date_format(start)}</div>
            <div><b>Bitiş:</b> ${gantt.templates.tooltip_date_format(end)}</div>
            <div><b>İlerleme:</b> ${Math.round(task.progress * 100)}%</div>
          </div>
        `;
      } else {
        return `
          <div style="padding: 12px; max-width: 300px;">
            <div style="font-weight: bold; font-size: 14px; margin-bottom: 8px;">${task.gorevAdi}</div>
            <div><b>Sipariş:</b> ${task.siparisNo}</div>
            <div><b>Departman:</b> ${task.departmanAdi}</div>
            <div><b>Personel:</b> ${task.personelAdi}</div>
            <div><b>Durum:</b> ${task.durum}</div>
            <div><b>Süre:</b> ${task.duration}h</div>
            <div><b>Başlangıç:</b> ${gantt.templates.tooltip_date_format(start)}</div>
            <div><b>Bitiş:</b> ${gantt.templates.tooltip_date_format(end)}</div>
            <div><b>İlerleme:</b> ${Math.round(task.progress * 100)}%</div>
          </div>
        `;
      }
    };

    gantt.templates.timeline_cell_class = function(task, date) {
      const hour = date.getHours();
      if (hour < 7 || hour >= 23) {
        return "non-working-time";
      }
      return "";
    };

    // Gantt'ı başlat
    gantt.init(ganttContainer.current);
    
    // Event handler'lar
    if (onTaskUpdate) {
      gantt.attachEvent("onAfterTaskUpdate", (id, task) => {
        onTaskUpdate(id, task);
      });
    }

    if (onLinkUpdate) {
      gantt.attachEvent("onAfterLinkUpdate", (id, link) => {
        onLinkUpdate(id, link);
      });
    }

    // Resize event
    const handleResize = () => {
      gantt.render();
    };

    window.addEventListener('resize', handleResize);

    return () => {
      gantt.clearAll();
      window.removeEventListener('resize', handleResize);
    };
  }, [onTaskUpdate, onLinkUpdate]);

  useEffect(() => {
    if (tasks && links) {
      gantt.clearAll();
      
      const dateRange = calculateDateRange(tasks);
      gantt.config.start_date = dateRange.start;
      gantt.config.end_date = dateRange.end;
      
      gantt.parse({ data: tasks, links: links });
      
      if (tasks.length > 0) {
        setTimeout(() => {
          const firstTask = tasks.find(t => t.type !== 'project');
          if (firstTask && firstTask.start_date) {
            gantt.showDate(new Date(firstTask.start_date));
          }
        }, 100);
      }
    }
  }, [tasks, links]);

  return (
    <div 
      ref={ganttContainer} 
      style={{ 
        width: '100%', 
        height: height,
        minHeight: '500px',
        overflow: 'hidden'
      }}
      className="gantt-container-fullpage"
    />
  );
};

export default GanttChart;
