import React from 'react';
import { StyleSheet, View } from 'react-native';
import { Divider, Text } from 'react-native-elements';


function TextArea({text, title}) {
    const styles = StyleSheet.create({
        container: {
            alignSelf: 'stretch',
            alignItems: 'flex-start',
            marginTop: 20
        }
    })
    return (
        <View style={styles.container}>
            <Text h4>{title}</Text>
            <Text h5>{text}</Text>
            <Divider style={{height: 2, alignSelf: 'stretch', backgroundColor: "#e1e8ee"}} />
        </View>
    );
}

export default TextArea;