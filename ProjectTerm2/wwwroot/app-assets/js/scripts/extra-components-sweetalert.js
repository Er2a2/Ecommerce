/*
* Sweet Alerts - Extra Components
*/

$(function () {
	"use strict";

	$('.btn-message').click(function () {
		swal("این یک پیام است!");
	});

	$('.btn-title-text').click(function () {
		swal("این یک پیام است!", "زیباست، نه؟")
	});

	$('.btn-timer').click(function () {
		swal({
			title: "هشدار بسته شدن خودکار!",
			text: "2 ثانیه دیگه میبندم",
			timer: 2000,
			buttons: false
		});
	});

	$('.btn-success-message').on('click', function () {
		swal({
			title: 'Success',
			icon: 'success'
		})
	})
	$('.btn-warning-message').on('click', function () {
		swal({
			title: 'Warning',
			icon: 'warning'
		})
	})
	$('.btn-error-message').on('click', function () {
		swal({
			title: 'Error',
			icon: 'error'
		})
	})
	$('.btn-info-message').on('click', function () {
		swal({
			title: 'Info',
			icon: 'info'
		})
	})



	$('.btn-success').click(function () {
		swal("بسیار عالی!", "دکمه را زدی!", "با موفقیت انجام شد");
	});

	$('.btn-warning-confirm').click(function () {
		swal({
			title: "مطمئنی؟",
			text: "شما نمی توانید این فایل خیالی را بازیابی کنید!",
			icon: 'warning',
			buttons: {
				cancel: true,
				delete: 'بله، حذفش کن'
			}
		})
	});

	$('.btn-warning-cancel').click(function () {
		swal({
			title: "مطمئنی؟",
			text: "شما نمی توانید این فایل خیالی را بازیابی کنید!",
			icon: 'warning',
			dangerMode: true,
			buttons: {
				cancel: 'خیر، لطفا!',
				delete: 'بله، حذفش کن'
			}
		}).then(function (willDelete) {
			if (willDelete) {
				swal("پوف! فایل خیالی شما حذف شد!", {
					icon: "success",
				});
			} else {
				swal("فایل خیالی شما امن است", {
					title: 'لغو شده',
					icon: "error",
				});
			}
		});
	});

	$('.btn-custom-icon').click(function () {
		swal({
			title: "شیرین!",
			text: "در اینجا یک تصویر سفارشی است.",
			icon: '../../../app-assets/images/favicon/apple-touch-icon-152x152.png'
		});
	});

	$('.btn-message-html').click(function () {
		var el = document.createElement('span'),
			t = document.createTextNode("پیام HTML سفارشی!!");
		el.style.cssText = 'color:#F6BB42';
		el.appendChild(t);
		swal({
			title: 'هشدار HTML!',
			content: {
				element: el,
			}
		});
	})


	$('.btn-input').click(function () {
		swal("یه چیز جالب بنویس:", {
			content: "input",
		})
			.then(function (value) {
				if (value === false) return false;
				if (value === "") {
					swal("باید چیزی بنویسی!", "", "خطا");
					return false;
				}
				swal('شما نوشته اید: ' + value);
			})
	});

	$('.btn-theme').click(function () {
		swal({
			title: "تم ها!",
			text: "در اینجا موضوع توییتر برای SweetAlert است!",
			confirmButtonText: "سرد!",
			customClass: 'twitter'
		});
	});

	$('.btn-ajax').click(function () {
		swal({
			text: 'جستجوی فیلم به عنوان مثال، "لا لا لند".',
			content: "input",
			button: {
				text: "جستجو!",
				closeModal: false,
			},
		})
			.then(function (name) {
				if (!name) throw null;

				return fetch('https://itunes.apple.com/search?term=' + name + '&entity=movie');
			})
			.then(function (results) {
				return results.json();
			})
			.then(function (json) {
				var movie = json.results[0];

				if (!movie) {
					return swal("فیلمی یافت نشد!");
				}

				var name = movie.trackName;
				var imageURL = movie.artworkUrl100;

				swal({
					title: "نتیجه برتر:",
					text: name,
					icon: imageURL,
				});
			})
			.catch(function (err) {
				if (err) {
					swal("اوه نه", "درخواست  AJAX با شکست مواجه شد!", "خطا");
				} else {
					swal.stopLoading();
					swal.close();
				}
			});
	});

});