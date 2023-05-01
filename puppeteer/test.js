const puppeteer = require('puppeteer');
(async () => {
  const browser = await puppeteer.launch({
    headless: false,
    args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']  
  });
    const page = await browser.newPage();
    try{
    await page.goto('https://8081-fafbfacfafafcaabbdcbdedafdfcabbbcaaa.project.examly.io/');
    await page.setViewport({
      width:1200,
      height:800,
    })
      await page.click('#signupLink');
      await page.waitForNavigation();
      await page.type('#email', 'test@gmail.com');
      await page.type('#username', 'testuser');
      await page.type('#mobileNumber', '9876543210');
      await page.type('#password', 'Test@123');
      await page.type('#confirmPassword', 'Test@123');
      await page.click('#submitButton');
      await page.waitForNavigation();
      await page.waitForSelector('#loginBox',{timeout:3000});
      console.log('TESTCASE:FE_Signup:success');
    }
     catch(e){
      console.log('TESTCASE:FE_Signup:failure');
    }
 
    const page1 = await browser.newPage();
    try{
    await page1.goto('https://8081-fafbfacfafafcaabbdcbdedafdfcabbbcaaa.project.examly.io/');
    await page1.setViewport({
      width:1200,
      height:800,
    })
      await page1.type('#email', 'test@gmail.com');
      await page1.type('#password', 'Test@123');
      await page1.click('#loginButton');
      await page1.waitForNavigation();
      await page1.waitForSelector('#productHomeButton',{timeout:3000});
      console.log('TESTCASE:FE_Login:success');
    }
     catch(e){
      console.log('TESTCASE:FE_Login:failure');
    }

    const page2 = await browser.newPage();
    try{
    await page2.goto('https://8081-fafbfacfafafcaabbdcbdedafdfcabbbcaaa.project.examly.io/');
    await page2.setViewport({
      width:1200,
      height:800,
    })
    await page2.type('#email', 'test@gmail.com');
    await page2.type('#password', 'Test@123');
    await page2.click('#loginButton');
      await page2.waitForNavigation();
      await page2.waitForSelector('#productHomeButton',{timeout:3000});
      await page2.click('#productHomeButton');
      await page2.waitForSelector('#grid1',{timeout:3000});
      await page2.click('#productCardButton');
      await page2.waitForSelector('#productCardBody',{timeout:3000});
      await page2.click('#productOrderButton');
      await page2.waitForSelector('#productOrderBody',{timeout:3000});
      await page2.click('#logoutButton');
      await page2.waitForSelector('#loginBox',{timeout:3000});
      console.log('TESTCASE:FE_UserOperation:success');
    }
     catch(e){
      console.log('TESTCASE:FE_UserOperation:failure');
    }

  const page3 = await browser.newPage();
  try{
  await page3.goto('https://8081-fafbfacfafafcaabbdcbdedafdfcabbbcaaa.project.examly.io/');
  await page3.setViewport({
    width:1200,
    height:800,
  })
    await page3.type('#email', 'admin@gmail.com');
    await page3.type('#password', 'Admin@123');
    await page3.click('#loginButton');
    await page3.waitForNavigation();
    await page3.waitForSelector('#adminProductButton',{timeout:3000});
    await page3.click('#editProduct1');
    await page3.waitForSelector('#addProductButton',{timeout:3000});
    await page3.click('#adminOrderButton');
    await page3.waitForSelector('#orderId',{timeout:3000});
    console.log('TESTCASE:FE_AdminOperation:success');
  }
   catch(e){
    console.log('TESTCASE:FE_AdminOperation:failure');
  }finally{
    await page.close();
    await page1.close();
    await page2.close();
    await page3.close();

    await browser.close();
  }
  
})();