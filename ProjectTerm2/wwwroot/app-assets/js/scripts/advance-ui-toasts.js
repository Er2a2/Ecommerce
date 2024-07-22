/*
 * Toasts - Advanced UI 
 */

// Basic Toast

$('.toast-basic').on('click', function () {
    M.toast({
        html: 'من یک اعلان هستم!'
    })
})

// Custom Toast

$('.toast-custom').on('click', function () {
    var toastHTML = '<span>من محتوای یک اعلان هستم</span><button class="btn-flat toast-action">بازگشت</button>';
    M.toast({
        html: toastHTML
    });
});

// Toast With Callback 

$('.toast-callback').on('click', function () {
    M.toast({
        html: 'من یک اعلان هستم!',
        completeCallback: function () {
            alert('اعلان شما رد شد')
        }
    })
});

$('.toast-rounded').on('click', function () {
    M.toast({
        html: 'من یک اعلان هستم!',
        classes: 'rounded'
    });
})