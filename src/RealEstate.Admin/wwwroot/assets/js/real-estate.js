$(document).ready(function () {
  // validation for login form
  $(".login-form").on("submit", function (e) {
    if (
      $("input[name='Username']").val() == "" ||
      $("input[name='Password']").val() == ""
    ) {
      e.preventDefault();
      toastr["error"]("Kullanıcı adı veya parola boş bırakılamaz.", "", {
        positionClass: "toast-top-right",
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        newestOnTop: true,
        rtl: $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
      });
    }
  });

  // validation for forgot password form
  $(".forgotpassword-form").on("submit", function (e) {
    if ($("input[name='Email']").val() == "") {
      e.preventDefault();
      toastr["error"]("E-posta alanı boş bırakılamaz.", "", {
        positionClass: "toast-top-right",
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        newestOnTop: true,
        rtl: $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
      });
    }
  });

  // validation for reset password form
  $(".resetpassword-form").on("submit", function (e) {
    if (
      $("input[name='Password']").val() == "" ||
      $("input[name='PasswordConfirm']").val() == ""
    ) {
      e.preventDefault();
      toastr["error"]("Parola alanları boş bırakılamaz.", "", {
        positionClass: "toast-top-right",
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        newestOnTop: true,
        rtl: $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
      });
    } else if (
      $("input[name='Password']").val() !=
      $("input[name='PasswordConfirm']").val()
    ) {
      e.preventDefault();
      toastr["error"]("Parolalar eşleşmiyor.", "", {
        positionClass: "toast-top-right",
        closeButton: true,
        progressBar: true,
        preventDuplicates: true,
        newestOnTop: true,
        rtl: $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
      });
    }
  });
});
