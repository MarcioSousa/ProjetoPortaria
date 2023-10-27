document.addEventListener('DOMContentLoaded', function() {
    const calendar = document.querySelector('.cal');
    const monthName = document.querySelector('.cal-month-name');
    const prevButton = calendar.querySelector('button:first-of-type');
    const nextButton = calendar.querySelector('button:last-of-type');
    const calDays = document.querySelector('.cal-days');

    const months = [
        'Janerio', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
        'Julho', 'Agosto', 'Setembro', 'Outobro', 'Novembro', 'Dezembro'
    ];

    const currentDate = new Date();
    let currentMonth = currentDate.getMonth();
    let currentYear = currentDate.getFullYear();

    function updateCalendar() {
        monthName.textContent = months[currentMonth];
        calDays.innerHTML = '';

        const lastDay = new Date(currentYear, currentMonth + 1, 0).getDate();

        for (let i = 1; i <= lastDay; i++) {
            const dayButton = document.createElement('button');
            dayButton.textContent = i;
            dayButton.classList.add('btn', 'cal-btn');
            calDays.appendChild(dayButton);
        }
    }

    prevButton.addEventListener('click', function() {
        currentMonth--;
        if (currentMonth < 0) {
            currentMonth = 11;
            currentYear--;
        }
        updateCalendar();
    });

    nextButton.addEventListener('click', function() {
        currentMonth++;
        if (currentMonth > 11) {
            currentMonth = 0;
            currentYear++;
        }
        updateCalendar();
    });

    // Initial setup
    updateCalendar();
});