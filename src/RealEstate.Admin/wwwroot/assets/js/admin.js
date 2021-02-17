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

  // validation for account settings form
  $(".accountsettings-form").on("submit", function (e) {
    if (
      $("input[name='UserName']").val() == "" ||
      $("input[name='Email']").val() == ""
    ) {
      e.preventDefault();
      toastr["error"](
        "Kullanıcı adı ve e-posta alanları boş bırakılamaz.",
        "",
        {
          positionClass: "toast-top-right",
          closeButton: true,
          progressBar: true,
          preventDuplicates: true,
          newestOnTop: true,
          rtl:
            $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
        }
      );
    } else if ($("input[name='CurrentPassword']").val() != "") {
      if (
        $("input[name='NewPassword']").val() == "" ||
        $("input[name='NewPasswordConfirm']").val() == ""
      ) {
        e.preventDefault();
        toastr["error"](
          "Lütfen tüm parola alanlarını doldurunuz. Eğer parolanızı değiştirmek istemiyorsanız güncel parola alanını boş bırakınız.",
          "",
          {
            positionClass: "toast-top-right",
            closeButton: true,
            progressBar: true,
            preventDuplicates: true,
            newestOnTop: true,
            rtl:
              $("body").attr("dir") === "rtl" ||
              $("html").attr("dir") === "rtl",
          }
        );
      } else if (
        $("input[name='NewPassword']").val() !=
        $("input[name='NewPasswordConfirm']").val()
      ) {
        e.preventDefault();
        toastr["error"]("Parolalar uyuşmuyor.", "", {
          positionClass: "toast-top-right",
          closeButton: true,
          progressBar: true,
          preventDuplicates: true,
          newestOnTop: true,
          rtl:
            $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
        });
      } else if (
        $("input[name='NewPassword']").val() ==
          $("input[name='NewPasswordConfirm']").val() &&
        $("input[name='NewPassword']").val().length < 6
      ) {
        e.preventDefault();
        toastr["error"]("Parola 6-12 karakter uzunluğunda olmalıdır.", "", {
          positionClass: "toast-top-right",
          closeButton: true,
          progressBar: true,
          preventDuplicates: true,
          newestOnTop: true,
          rtl:
            $("body").attr("dir") === "rtl" || $("html").attr("dir") === "rtl",
        });
      }
    }
  });

  var activeSidenav = $(
    ".sidenav-link[href='" + window.location.pathname + "']"
  ).parent();

  if (activeSidenav.parent().hasClass("sidenav-menu")) {
    activeSidenav.parent().parent().addClass("open");
    activeSidenav.addClass("active");
  } else {
    activeSidenav.addClass("active");
  }
});

$("input[name='CurrentPassword']").on("input", function () {
  if ($("input[name='CurrentPassword']").val() != "") {
    $("input[name='NewPassword']").prop("disabled", false);
    $("input[name='NewPasswordConfirm']").prop("disabled", false);
  } else {
    $("input[name='NewPassword']").prop("disabled", true);
    $("input[name='NewPasswordConfirm']").prop("disabled", true);
  }
});

$(function () {
  $(".filter-select").each(function () {
    $(this)
      .wrap('<div class="position-relative"></div>')
      .select2({
        placeholder: "Select value",
        dropdownParent: $(this).parent(),
      });
  });
});

// Auto update layout
(function () {
  window.layoutHelpers.setAutoUpdate(true);
})();

// Collapse menu
(function () {
  if (
    $("#layout-sidenav").hasClass("sidenav-horizontal") ||
    window.layoutHelpers.isSmallScreen()
  ) {
    return;
  }

  try {
    window.layoutHelpers.setCollapsed(
      localStorage.getItem("layoutCollapsed") === "true",
      false
    );
  } catch (e) {}
})();

$(function () {
  // Initialize sidenav
  $("#layout-sidenav").each(function () {
    new SideNav(this, {
      orientation: $(this).hasClass("sidenav-horizontal")
        ? "horizontal"
        : "vertical",
    });
  });

  // Initialize sidenav togglers
  $("body").on("click", ".layout-sidenav-toggle", function (e) {
    e.preventDefault();
    window.layoutHelpers.toggleCollapsed();
    if (!window.layoutHelpers.isSmallScreen()) {
      try {
        localStorage.setItem(
          "layoutCollapsed",
          String(window.layoutHelpers.isCollapsed())
        );
      } catch (e) {}
    }
  });

  if ($("html").attr("dir") === "rtl") {
    $("#layout-navbar .dropdown-menu").toggleClass("dropdown-menu-right");
  }
});
