Feature('NavigateHomepage');

Scenario('Go to Leaderboard', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Leaderboard');
    I.see('Leaderboard');
    I.clickLink('//html/body/section[1]/div/div/div/ul/li[2]/a');
    I.waitForText('This Weeks Stars');
});

Scenario('Go to Activity', (I) => {
    I.amOnPage('http://devforum.azurewebsites.net/');
    I.waitForText('Activity');
    I.see('Activity');
    I.clickLink('//html/body/section[1]/div/div/div/ul/li[3]/a');
    I.waitForText('is a new member in the forum')
})