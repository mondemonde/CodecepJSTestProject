
Feature('Search');

Scenario('Do successful search', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.fillField('term','home');
    I.click('Go');
    I.see('Can i Access');
});

Scenario('Do unsuccessful search', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForElement('//*[@id="term"]');
    I.fillField('//*[@id="term"]','gibberish');
    I.waitForElement('//*[@id="main"]/div/div[2]/div/div[2]/form/div/span/button');
    I.click('//*[@id="main"]/div/div[2]/div/div[2]/form/div/span/button');
    I.see('Sorry no results found');
});

Scenario('Go to Badges page', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Badges');
    I.click({ xpath: '/html/body/section[1]/div/div/div/ul/li[4]/a'});
    //I.waitForElement('.mainheading', 5);
    I.see('Photogenic');
});