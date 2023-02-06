module.exports = {
    moduleDirectories: [
        'node_modules'
      ],
      testEnvironment: "jsdom",
      transform: {
        "\\.tsx?$": "ts-jest",
        "\\.jsx?$": "babel-jest", // if you have jsx tests too
      },   
      "setupFilesAfterEnv": [
        "<rootDir>/src/setupTests.ts"
      ],
      moduleNameMapper: {
        '^axios$': require.resolve('axios'),
      },
      transformIgnorePatterns: [
        "[/\\\\]node_modules[/\\\\](?!lodash-es/).+\\.js$"
      ],
  };