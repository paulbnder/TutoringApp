import React from 'react';
import { StyleSheet, View } from 'react-native';
import { Divider, Text } from 'react-native-elements';


function TextArea({text, title}) {
    const styles = StyleSheet.create({
        container: {
            alignSelf: 'stretch',
            alignItems: 'center'
        }
    })
    return (
        <View style={styles.container}>
            <Divider style={{height: 2, alignSelf: 'stretch', backgroundColor: "#e1e8ee"}} />
            <Text h3>{title}</Text>
            <Text h5>{text}</Text>
        </View>
    );
}

export default TextArea;