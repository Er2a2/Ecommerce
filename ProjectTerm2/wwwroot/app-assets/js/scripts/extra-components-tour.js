/*extra components tour */
/*-------------------- */

$(document).ready(function () {
  displayTour();
  // tour initialize
  var tour = new Shepherd.Tour({
    defaultStepOptions: {
      cancelIcon: {
        enabled: true
      },
      classes: 'tour-container',
      scrollTo: { behavior: 'smooth', block: 'center' }
    }
  });
  // step 1
  tour.addStep({
    title: 'این عنوان صفحه است.',
    text: 'شما می توانید این بخش را به عنوان نیاز خود حذف کنید.',
    attachTo: {
      element: '.breadcrumbs-title span',
      on: 'right'
    },
    buttons: [
      {
        action: function () {
          return this.cancel();
        },
        classes: 'btn btn-light-indigo',
        text: 'خروج'
      },
      {
        action: function () {
          return this.next();
        },
        classes: 'btn indigo',
        text: 'بعدی'
      }
    ],
    id: 'welcome'
  });
  // step 2
  tour.addStep({
    title: 'از اینجا زبان را تغییر دهید',
    text: 'ما چهار زبان مختلف را ارائه می دهیم.',
    attachTo: {
      element: '.dropdown-language .translation-button',
      on: 'bottom'
    },
    buttons: [
      {
        action: function () {
          return this.cancel();
        },
        classes: 'btn btn-light-indigo',
        text: 'خروج'
      },
      {
        action: function () {
          return this.back();
        },
        classes: 'btn btn-light-indigo',
        text: 'قبلی'
      },
      {
        action: function () {
          return this.next();
        },
        classes: 'btn indigo',
        text: 'بعدی'
      }
    ],
  });
  // step 3
  tour.addStep({
    title: 'برنامه های مورد علاقه',
    text: 'می توانید به برنامه های مورد علاقه خود دسترسی سریع داشته باشید.',
    attachTo: {
      element: '.fixed-action-btn .btn-floating',
      on: 'left'
    },
    buttons: [
      {
        action: function () {
          return this.cancel();
        },
        classes: 'btn btn-light-indigo',
        text: 'خروج'
      },
      {
        action: function () {
          return this.back();
        },
        classes: 'btn btn-light-indigo',
        text: 'قبلی'
      },
      {
        action: function () {
          return this.next();
        },
        classes: 'btn indigo',
        text: 'انجام شد'
      }
    ],
    modalOverlayOpeningPadding: '10'
  });

  $(window).resize(displayTour)
  // function to remove tour on small screen
  function displayTour() {
    window.resizeEvt;
    if ($(window).width() > 576) {
      $('#tour').on("click", function () {
        clearTimeout(window.resizeEvt);
        tour.start();
      })
    }
    else {
      $('#tour').on("click", function () {
        clearTimeout(window.resizeEvt);
        tour.cancel()
        window.resizeEvt = setTimeout(function () {
          alert("Tour only works for large screens!");
        }, 250);;
      })
    }
  }
});