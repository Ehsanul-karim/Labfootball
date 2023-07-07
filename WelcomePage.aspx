<!doctype html>
<html lang="en">
<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="prixima/css/styleWelcome.css" rel="stylesheet" />
  <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
  <link href="owl.carousel.min.css" rel="stylesheet" />
  <link href="owl.theme.default.min.css" rel="stylesheet" />
  <!-- Bootstrap CSS -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="icon" type="image/jpeg" href="Images/my%20website%20logo.jpeg">
  <title>
    Football Today
  </title>

    <style>
    #about {
    background: linear-gradient(rgb(203 212 243 / 90%), rgb(47 193 85 / 90%)), url(../Images/39.png) fixed center center;
    background-size: cover;
    padding: 50px 0;
    }
        #services {
    background: linear-gradient(rgba(0, 0, 0, 0.9), rgba(0, 0, 0, 0.8)), url("./Images/serviceback.jpg") , #082032;
    background-size: cover;
    padding:50px 0;
    background-position: center;
    background-repeat: no-repeat;
    }
        footer {
    background: linear-gradient(0deg, rgba(8, 32, 50, 0.9), rgba(8, 32, 50, 0.9)), url('./Images/footer.jpg'), #082032;
    }
    #portfolio .container .section-title p {
         margin-bottom: 40px;
         color: #083a78;
    }

        .project {
        background-color: #e4e2f9;
        }
        .circle-image {
  width: 300px;
  height: 300px;
  border-radius: 50%;
  overflow: hidden;
}

.circle-image img {
  width: 100%;
  object-fit: cover;
}
    #team {
    background: linear-gradient(rgb(183 214 245 / 75%), rgb(0 32 50 / 75%));
    padding: 50px 0;
    }

    footer .social-icons a {
        font-size:30px;
    }
        footer .social-icons a:hover {
        color:#a6bfe3
    }
    </style>
</head>
<body>
  <header id="header" class="fixed-top">
    <div class="container-fluid">
      <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
        <div class="container-fluid">
          <a class="navbar-brand" href="#">
            <img src="Images/pngegg (2).png" alt="logo" style="width: 55px; height: auto;">
          </a>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <a class="nav-link" aria-current="page" href="#">Home</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#about">About</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#services">Services</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#portfolio">Portfolio</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#team">Developer</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#contact">Contact</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="d-flex">
            <button class="btn btn-outline-success login" type="submit"><a href="loginPage.aspx">Login</a></button>
            <button class="btn btn-outline-success register" type="submit"><a href="signUp.aspx">Register</a></button>
        </div>

      </nav>
    </div>
  </header>
  <div class="carosal">
    <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
      <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active"
          aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1"
          aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2"
          aria-label="Slide 3"></button>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="Images/1.jpg" class="d-block carosal-img" alt="...">
          <div class="carousel-caption d-none d-md-block">
            <div class="carosal-h">Football Today</div>
            <div class="carosal-p">All clubs unites here</div>
          </div>
        </div>
        <div class="carousel-item">
          <img src="Images/pngegg (5).png" class="d-block carosal-img" alt="...">
          <div class="carousel-caption d-none d-md-block">
            <div class="carosal-h">Football Today</div>
            <div class="carosal-p">All clubs unites here</div>
          </div>
        </div>
        <div class="carousel-item">
          <img src="Images/pngegg (6).png" class="d-block carosal-img" alt="...">
          <div class="carousel-caption d-none d-md-block">
            <div class="carosal-h">Football Today</div>
            <div class="carosal-p">All clubs unites here</div>
          </div>
        </div>
      </div>
      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions"
        data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions"
        data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </div>

  <section id="about" class="about">
    <div class="container">
        <div class="section-title">
            <h2 style="color:#563737; border-bottom: 3px dashed #0f008f;">About Us</h2>    
        </div>
        <div class="row content">
            <div class="col-lg-6">
                <p class="h4 text-muted">Welcome to our football manager website, where you can:</p>
                <ul class="list-unstyled" style="font-size:20px;">
                    <li style="color:#0d400e;">Create and manage your own football team</li>
                    <li style="color:#0d400e;">Add and update team details, including squad information</li>
                    <li style="color:#0d400e;">Set up player formations and tactics</li>
                </ul>
            </div>
            <div class="col-lg-6 pt-4 pt-lg-0">
                <p class="h4 text-muted">Our platform provides a range of features:</p>
                <ul class="list-unstyled"  style="font-size:20px;">
                    <li style="color:#0d400e;">Player transfer system, allowing you to buy and sell players with other clubs</li>
                    <li style="color:#0d400e;">League management tools to schedule and track matches</li>
                    <li style="color:#0d400e;">In-depth player statistics and performance analysis</li>
                </ul>
                <a href="https://en.wikipedia.org/wiki/Football_Manager" class="btn btn-outline-success btn-lg mt-3" style="color:#07301d;">Learn More</a>
            </div>
        </div>
    </div>
</section>

<section id="services" class="services section-bg">
  <div class="container" data-aos="fade-up">
      <div class="section-title" > 
          <h2  style="color: #9dff91; border-bottom: 3px dashed #dce0e3;">Services</h2>
          <p style="color:#4aed8b;">
              Our website provides a range of services tailored for football enthusiasts, including the following features:
          </p>
      </div>
      <div class="row">
              <div class="col-md-6 flex align-items-stretch align-items-center" data-aos="zoom-in"
        data-aos-delay="100">
              <div class="icon-box" style="background:#b3f7b2c7;">
                  <div class="icon">
                      <img src="Images/managerWelcome.jpg" class="section-img" alt="">
                  </div>
                  <h4><a href="">Manager Panel</a></h4>
                  <p style="font-size:18px;line-height:1.5;margin-bottom:10px">Managers have access to powerful tools for team management:</p>
                  <ul style="margin-left:20px;font-size:16px;line-height:1.5">
                      <li>Create and manage their own football team</li>
                      <li>Add and update player information</li>
                      <li>Set up team formations for upcoming matches</li>
                      <li>Update and track the injury records of players</li>
                      <li>Sell players and engage in the transfer market</li>
                  </ul>
              </div>
          </div>
 <div class="col-md-6 flex align-items-stretch align-items-center" data-aos="zoom-in" data-aos-delay="100">
              <div class="icon-box"  style="background:#b3f7b2c7;">
                  <div class="icon">
                      <img src="Images/supporterWelcomereal.jpg" class="section-img" alt="">
                  </div>
                  <h4><a href=""> Supporter Panel</a></h4>
                    <p style="font-size:18px;line-height:1.5;margin-bottom:10px">Supporters can log in to their accounts and access various features:</p> 
                    <ul  style="margin-left:20px;font-size:16px;line-height:1.5">
                      <li>View their chosen team's records and performance</li>
                      <li>Check the injury status of players and the manager's plans for the next game</li>
                      <li>Observe the transfer market, including players on sale and teams interested in acquiring them</li>
                  </ul>
              </div>
          </div>


      </div>
  </div>
</section>


<!-- Portfolio Section -->
<section id="portfolio" class="portfolio" style="background-color: #b7d6f5;">
  <div class="container" data-aos="fade-up">
<div class="section-title">
  <h2 style="color:#06566e; border-bottom: 3px dashed #3a26dd;">Our Portfolio</h2>
  <p>At our football manager website, we offer a comprehensive platform designed for both managers and supporters. Our innovative features cater to the needs of football enthusiasts, providing an immersive experience like no other.</p>
  <p>Explore the capabilities of our Manager Panel and Supporter Panel below:</p>
</div>
      <div class="portfolio">
          <div class="project">
  <img src="Images/project1.jpg"  alt="Project 1">
  <h3>Team Lineup Management</h3>
  <p>Elevate your team's performance by efficiently managing and organizing your players' positions, formations, and tactical strategies. Our team lineup management feature ensures that you have the best lineup on the field for each match.</p>
</div>

<div class="project">
  <img src="Images/project2.jpg" alt="Project 2">
  <h3>Training Schedule Optimization</h3>
  <p>Maximize your team's potential through effective training scheduling. Our system helps you plan and optimize training sessions, ensuring that your players receive the right balance of physical fitness, skill development, and tactical drills.</p>
</div>

<div class="project">
  <img src="Images/project3.jpg" alt="Project 3">
  <h3>Player Scouting and Recruitment</h3>
  <p>Discover hidden talent and strengthen your team by utilizing our player scouting and recruitment feature. Access an extensive database of players, analyze their stats, and make informed decisions to sign the best prospects for your team.</p>
</div>

<div class="project">
  <img src="Images/project4.jpg" alt="Project 4">
  <h3>Fixture Management and Match Scheduling</h3>
  <p>Effortlessly manage your team's fixtures and match schedules with our intuitive fixture management system. Stay organized, track match results, and make strategic decisions based on upcoming fixtures to lead your team to success.</p>

</div>
      </div>
  </div>
</section>

<section id="team">
    <div class="container">
           <div class="section-title">
          <h2 style="color:#241a76; border-bottom: 3px dashed #252525;">Developer</h2>
      </div>
        <div class="row justify-content-center">
            <div class="col-lg-5 py-5">
<div class="row">
    <div class="col-lg-12">
        <p style="font-size: 20px; font-weight: bold; margin-bottom: 10px;">Hello, I'm Ehsanul Karim,</p>
        <p style="font-size: 18px; margin-bottom: 20px; color:#262e11">a passionate developer currently pursuing my degree at <span style="color: #241a76;">Khulna University of Engineering & Technology (KUET)</span>. I'm enrolled in the <span style="color: #241a76;">CSE</span> Department, and My Roll is <span style="color: #241a76;">1907039</span>. Currently in <span style="color: #241a76;">3rd</span> year <span style="color: #241a76;">1st </span>Semester, I'm dedicated to honing my skills and expanding my knowledge in the field of web development.</p>
    </div>
</div>
            </div>
      <div class="col-lg-5 d-flex align-items-center justify-content-center">
        <div class="circle-image">
          <img src="Images/developerImage.jpg" class="img-fluid" alt="Developer Image">
        </div>
      </div>
        </div>
    </div>
</section>


<!--  Footer  -->
    <footer>
        <div class="footer-top text-center" id="contact">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-6 text-center">
                        <h4 class="navbar-brand">Football Today<span class="dot">.</span></h4>
             <p>Stay connected with the latest updates in the world of football. Our website provides a comprehensive manager panel and supporter panel for an enhanced football experience.</p>
                        <div class="col-auto social-icons">
                            <a href="https://www.facebook.com/ehsanulkarim.talha?mibextid=ZbWKwL"><i class='bx bxl-facebook'></i></a>
                            <a href="https://twitter.com/"><i class='bx bxl-twitter'></i></a>
                            <a href="https://www.instagram.com/_ehsanul_karim_"><i class='bx bxl-instagram'></i></a>
                            <a href="https://github.com/Ehsanul-karim"><i class='bx bxl-github'></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer-bottom text-center">
            <p class="mb-0">Copyright@2020. All rights Reserved</p>
        </div>
    </footer>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
    crossorigin="anonymous"></script>

</body>
</html>