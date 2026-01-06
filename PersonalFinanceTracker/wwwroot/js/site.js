
document.addEventListener('DOMContentLoaded', function () {
    
    fetch('/Budget/Progress')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch budget data');
            }
            return response.json();
        })
        .then(data => {
            
            const content = document.getElementById('content');
            if (content) {
                content.innerHTML = data.map(b => `
                    <div class="budget-item">
                        <strong>${b.category}:</strong> $${b.spent.toFixed(2)} / $${b.monthlyLimit.toFixed(2)}
                        <div class="progress-bar">
                            <div class="progress" style="width: ${Math.min((b.spent / b.monthlyLimit) * 100, 100)}%;"></div>
                        </div>
                    </div>
                `).join('');
            }
        })
        .catch(error => {
            console.error('Error loading budget progress:', error);
            
            const content = document.getElementById('content');
            if (content) {
                content.innerHTML = '<p>Error loading budget data. Please try again later.</p>';
            }
        });
});


function validateForm(form) {
    const inputs = form.querySelectorAll('input[required]');
    let isValid = true;
    inputs.forEach(input => {
        if (!input.value.trim()) {
            input.style.borderColor = 'red';
            isValid = false;
        } else {
            input.style.borderColor = '';
        }
    });
    return isValid;
}


